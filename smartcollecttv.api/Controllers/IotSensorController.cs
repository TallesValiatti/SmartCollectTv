using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using smartcollecttv.api.Data.Interfaces;
using smartcollecttv.api.Dtos.IotSensors;
using smartcollecttv.api.Models;

namespace smartcollecttv.api.Controllers;

[ApiController]
[Route("[controller]")]
public class IotSensorController : ControllerBase
{
    private readonly IIotSensorRepository _repo;

    public IotSensorController(IIotSensorRepository repo)
    {
        _repo = repo;
    }

    [HttpGet(Name = "GetIotSensors")]
    public async Task<IActionResult> GetAllAsync(int take, int skip)
    {
        return Ok(await _repo.GetAsync(take, skip));
    }

     [HttpGet("{id}", Name = "GetIotSensor")]
    public async Task<IActionResult> GetAsync([Required] string id, [FromQuery]string? partitionKey)
    {
        return Ok(await _repo.GetAsync(id, partitionKey));
    }
    
    [HttpPost(Name = "CreateIotSensor")]
    public async Task<IActionResult> CreateAsync(CreateIotSensorDto createIotSensorDto )
    {
        var iotSensor = new IotSensor
        {
            Id = Guid.NewGuid().ToString(),
            DeviceId = string.IsNullOrWhiteSpace (createIotSensorDto.DeviceId) ? string.Empty : createIotSensorDto.DeviceId.Trim(),            
            DateTime = createIotSensorDto.DateTime,
            Battery = createIotSensorDto.Battery,
            Distance = createIotSensorDto.Distance,
            Temperature = createIotSensorDto.Temperature,
            Humidity = createIotSensorDto.Humidity
        };

        await _repo.CreateAsync(iotSensor, iotSensor.DeviceId);

        return Ok(iotSensor);
    }

    [HttpPut(Name = "UpdateIotSensor")]
    public async Task<IActionResult> UpdateAsync(UpdateIotSensorDto updateIotSensorDto)
    {
        var partitionKey = updateIotSensorDto.DeviceId;
        var id = updateIotSensorDto.Id;
        
        var iotSensor = await _repo.GetAsync(id!, partitionKey);
        
        if(iotSensor is null)
            return BadRequest(
                new 
                {
                    Error = $"IotSensor with id '{id}' and PK '{partitionKey}' not found"
                }
            );

            iotSensor.DeviceId = string.IsNullOrWhiteSpace (updateIotSensorDto.DeviceId) ? string.Empty : updateIotSensorDto.DeviceId.Trim();
            iotSensor.DateTime = updateIotSensorDto.DateTime;
            iotSensor.Battery = updateIotSensorDto.Battery;
            iotSensor.Distance = updateIotSensorDto.Distance;
            iotSensor.Temperature = updateIotSensorDto.Temperature;
            iotSensor.Humidity = updateIotSensorDto.Humidity;
        
        await _repo.UpdateAsync(iotSensor, iotSensor.DeviceId);

        return Ok();
    }

    [HttpDelete("{id}", Name = "DeleteIotSensor")]
    public async Task<IActionResult> DeleteAsync([Required] string id, string? partitionKey)
    {
        var driver = await _repo.GetAsync(id!, partitionKey);
        
        if(driver is null)
            return BadRequest(
                new 
                {
                    Error = $"IotSensor with id '{id}' and PK '{partitionKey}' not found"
                }
            );

        await _repo.DeleteAsync(id, partitionKey);

        return Ok();
    }
}
