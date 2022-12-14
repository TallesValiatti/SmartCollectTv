using Microsoft.AspNetCore.Mvc;
using smartcollecttv.api.Data.Context;
using smartcollecttv.api.Data.Interfaces;

namespace smartcollecttv.api.Controllers;

[ApiController]
[Route("[controller]")]
public class CollectionPointController : ControllerBase
{
    private readonly ICollectionPointRepository _repo;

    public CollectionPointController(ICollectionPointRepository repo)
    {
        _repo = repo;
    }

    [HttpGet(Name = "GetCollectionPoints")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _repo.GetAllAsync());
    }
}
