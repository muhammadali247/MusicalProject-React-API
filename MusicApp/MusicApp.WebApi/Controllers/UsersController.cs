using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.Abstractions.Services;
using MusicApp.Application.Features.ArtistFeatures.Queries.ArtistGetByIdQry;
using MusicApp.Application.Features.UserFeatures.Queries.UserGetAllLimitedQry;
using MusicApp.Application.Features.UserFeatures.Queries.UserGetLimitedByIdQry;

namespace MusicApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IFileUploadService _fileUploadService;
    private readonly IMapper _mapper;

    public UsersController(IMediator mediator, IFileUploadService fileUploadService, IMapper mapper)
    {
        _mediator = mediator;
        _fileUploadService = fileUploadService;
        _mapper = mapper;
    }


    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var query = new UserGetAllLimitedQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }




    [HttpGet("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id)
    {
        var query = new UserGetLimitedByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }



    // POST api/<UsersController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
