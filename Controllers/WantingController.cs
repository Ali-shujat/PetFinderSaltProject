using Microsoft.AspNetCore.Mvc;
using PetFinderApi.Data;
using PetFinderApi.Data.ViewModels;

namespace PetFinderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WantingController : ControllerBase
{
    private Mapper mapper = new Mapper();
    private IWantingRepo _repo;
    public WantingController(IWantingRepo repo) => _repo = repo;

    [HttpGet]
    public ActionResult GetAll()
    {
        return Ok();
    }
    [HttpGet("{id}")]
    public ActionResult GetOne(int id)
    {
        return Ok();
    }
    [HttpPost]
    public ActionResult Create(WantingRequest request)
    {
        var Cat = mapper.WantingReqToCat(request);
        var Person = mapper.WantingReqToPerson(request);
        var Created = _repo.Create(request.EventInfo, Cat, Person, request.Position);
        return Ok();
    }
}
