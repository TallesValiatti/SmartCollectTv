using Microsoft.AspNetCore.Mvc;
using smartcollecttv.api.Data.Interfaces;

namespace smartcollecttv.api.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleRepository _repo;

    public VehicleController(IVehicleRepository repo)
    {
        _repo = repo;
    }

    [HttpGet(Name = "GetVehicles")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _repo.GetAllAsync());
    }
}
