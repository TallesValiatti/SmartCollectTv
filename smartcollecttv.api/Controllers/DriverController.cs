using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using smartcollecttv.api.Data.Interfaces;
using smartcollecttv.api.Dtos.Drivers;
using smartcollecttv.api.Models;

namespace smartcollecttv.api.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : ControllerBase
{
    private readonly IDriverRepository _repo;

    public DriverController(IDriverRepository repo)
    {
        _repo = repo;
    }

    [HttpGet(Name = "GetDrivers")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _repo.GetAllAsync());
    }

    [HttpGet("{id}", Name = "GetDriver")]
    public async Task<IActionResult> GetAsync([Required] string id, [FromQuery]string? partitionKey)
    {
        return Ok(await _repo.GetAsync(id, partitionKey));
    }

    [HttpPost(Name = "CreateDriver")]
    public async Task<IActionResult> CreateAsync(CreateDriverDto createDriverDto)
    {
        var driver = new Driver
        {
            Id = Guid.NewGuid().ToString(),
            Name = string.IsNullOrWhiteSpace (createDriverDto.Name) ? string.Empty : createDriverDto.Name.Trim(),
            Location = string.IsNullOrWhiteSpace (createDriverDto.Location) ? string.Empty : createDriverDto.Location.Trim(),
            RFID = string.IsNullOrWhiteSpace (createDriverDto.RFID) ? string.Empty : createDriverDto.RFID.Trim(),
            LastLogin = string.IsNullOrWhiteSpace (createDriverDto.LastLogin) ? string.Empty : createDriverDto.LastLogin.Trim()
        };

        await _repo.CreateAsync(driver, driver.RFID);

        return Ok(driver);
    }

    [HttpPut(Name = "UpdateDriver")]
    public async Task<IActionResult> UpdateAsync(UpdateDriverDto updateDriverDto)
    {
        var partitionKey = updateDriverDto.RFID;
        var id = updateDriverDto.Id;
        
        var driver = await _repo.GetAsync(id!, partitionKey);
        
        if(driver is null)
            return BadRequest(
                new 
                {
                    Error = $"Driver with id '{id}' and PK '{partitionKey}' not found"
                }
            );

        driver.Name = string.IsNullOrWhiteSpace (updateDriverDto.Name) ? string.Empty : updateDriverDto.Name.Trim();
        driver.Location = string.IsNullOrWhiteSpace (updateDriverDto.Location) ? string.Empty : updateDriverDto.Location.Trim();
        driver.RFID = string.IsNullOrWhiteSpace (updateDriverDto.RFID) ? string.Empty : updateDriverDto.RFID.Trim();
        driver.LastLogin = string.IsNullOrWhiteSpace (updateDriverDto.LastLogin) ? string.Empty : updateDriverDto.LastLogin.Trim();
        
        await _repo.UpdateAsync(driver, driver.RFID);

        return Ok();
    }

    [HttpDelete("{id}", Name = "DeleteDriver")]
    public async Task<IActionResult> DeleteAsync([Required] string id, string? partitionKey)
    {
        var driver = await _repo.GetAsync(id!, partitionKey);
        
        if(driver is null)
            return BadRequest(
                new 
                {
                    Error = $"Driver with id '{id}' and PK '{partitionKey}' not found"
                }
            );

        await _repo.DeleteAsync(id, partitionKey);

        return Ok();
    }
}
