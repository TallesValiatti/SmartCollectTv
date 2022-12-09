using Microsoft.AspNetCore.Mvc;
using smartcollecttv.api.Data.Context;
using smartcollecttv.api.Data.Interfaces;

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
}
