using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.Features.SongFeatures.Queries.SongGetAllQry;

namespace MusicApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SongsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SongsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var query = new SongGetAllQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    // GET api/<SongsController>/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<SongsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<SongsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<SongsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
