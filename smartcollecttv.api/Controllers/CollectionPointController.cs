using Microsoft.AspNetCore.Mvc;
using smartcollecttv.api.Data.Context;
using smartcollecttv.api.Data.Interfaces;

namespace smartcollecttv.api.Controllers;

[ApiController]
[Route("[controller]")]
public class CollectionPointController : ControllerBase
{
    private readonly ICollectionPointRepository _collectionPointRepository;

    public CollectionPointController(ICollectionPointRepository collectionPointRepository)
    {
        _collectionPointRepository = collectionPointRepository;
    }

    [HttpGet(Name = "GetCollectionPoints")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _collectionPointRepository.GetAllAsync());
    }
}
