using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Application.Features.ArtistFeatures.Commands.ArtistCreateCmd;
using MusicApp.Application.Features.ArtistFeatures.Commands.ArtistDeleteCmd;
using MusicApp.Application.Features.ArtistFeatures.Commands.ArtistUpdateCmd;
using MusicApp.Application.Features.ArtistFeatures.Queries.ArtistFullDetailsGetByIdQry;
using MusicApp.Application.Features.ArtistFeatures.Queries.ArtistGetAllQry;
using MusicApp.Application.Features.ArtistFeatures.Queries.ArtistGetByIdQry;


namespace MusicApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArtistsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ArtistsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var query = new ArtistGetAllQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }




    [HttpGet("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new ArtistGetByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{id}/details")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFullDetailsById(Guid id)
    {
        var query = new ArtistFullDetailsGetByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(ArtistCreateDTO artist)
    {
        var command = new ArtistCreateCommand(artist);
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = response }, null);
    }




    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, ArtistUpdateDTO artist)
    {
        var command = new ArtistUpdateCommand(id, artist);
        var response = await _mediator.Send(command);

        var query = new ArtistGetByIdQuery(response);
        var updatedArtist = await _mediator.Send(query);

        return Ok(updatedArtist);
    }




    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new ArtistDeleteCommand(id);
        var response = await _mediator.Send(command);
        return NoContent();
    }
}
