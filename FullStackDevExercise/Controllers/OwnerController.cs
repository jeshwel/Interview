using FullStackDevExercise.Models;
using FullStackDevExercise.Services.Contracts;
using FullStackDevExercise.Services.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace FullStackDevExercise.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OwnerController : ControllerBase
  {
    private readonly IOwnerService ownerService;
    public OwnerController(IOwnerService OwnerService)
    {
      ownerService = OwnerService;
    }
    // GET: api/<OwnerController>
    [HttpGet]
    public IActionResult Get()
    {
      var data = ownerService.GetAll();
      return Ok(data);
    }

    // GET api/<OwnerController>/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var data = ownerService.GetById(id);
      return Ok(data);
    }

    // POST api/<OwnerController>
    //Not following a 3 layered architecture here.
    //using DTO itself as there is no change in properties else a different view modal class is preferred.
    [HttpPost]
    public int Post(OwnerDTO OwnerDTO)
    {
      return ownerService.Save(OwnerDTO);
    }

    //// PUT api/<OwnerController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    // DELETE api/<OwnerController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      ownerService.Delete(id);
    }
  }
}
