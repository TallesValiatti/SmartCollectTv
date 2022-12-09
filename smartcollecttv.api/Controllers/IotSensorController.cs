using Microsoft.AspNetCore.Mvc;
using smartcollecttv.api.Data.Context;
using smartcollecttv.api.Data.Interfaces;

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
}
