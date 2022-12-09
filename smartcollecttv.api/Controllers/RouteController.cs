using Microsoft.AspNetCore.Mvc;
using smartcollecttv.api.Data.Interfaces;

namespace smartcollecttv.api.Controllers;

[ApiController]
[Route("[controller]")]
public class RouteController : ControllerBase
{
    private readonly IRouteRepository _repo;

    public RouteController(IRouteRepository repo)
    {
        _repo = repo;
    }

    [HttpGet(Name = "GetRoutes")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _repo.GetAllAsync());
    }
}
