using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.DTOs.MusicalProjectDTO;
using MusicApp.Application.Features.MusicalProjectFeatures.Commands.MusicalProjectCreateCmd;
using MusicApp.Application.Features.MusicalProjectFeatures.Commands.MusicalProjectDeleteCmd;
using MusicApp.Application.Features.MusicalProjectFeatures.Commands.MusicalProjectUpdateCmd;
using MusicApp.Application.Features.MusicalProjectFeatures.Queries.MusicalProjectGetAllQry;
using MusicApp.Application.Features.MusicalProjectFeatures.Queries.MusicalProjectGetByIdQry;

namespace MusicApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MusicalProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MusicalProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var query = new MusicalProjectGetAllQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }




    [HttpGet("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new MusicalProjectGetByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }




    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(MusicalProjectCreateDTO artist)
    {
        var command = new MusicalProjectCreateCommand(artist);
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response }, null);
    }




    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, MusicalProjectUpdateDTO musicalProject)
    {
        var command = new MusicalProjectUpdateCommand(id, musicalProject);
        var response = await _mediator.Send(command);

        var query = new MusicalProjectGetByIdQuery(response);
        var updatedMusicalProject = await _mediator.Send(query);

        return Ok(updatedMusicalProject);
    }




    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new MusicalProjectDeleteCommand(id);
        var response = await _mediator.Send(command);
        return NoContent();
    }
}
