using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.Abstractions.Services;
using MusicApp.Application.DTOs.EventDTOs;
using MusicApp.Application.Features.EventFeatures.Commands.EventCreateCmd;
using MusicApp.Application.Features.EventFeatures.Queries.EventGetAllQry;
using MusicApp.WebApi.DTOs.EventApiDTOs;

namespace MusicApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IFileUploadService _fileUploadService;
    private readonly IMapper _mapper;
    private readonly IValidator<EventCreateApiDTO> _eventValidator;

    public EventsController(IMediator mediator, IFileUploadService fileUploadService, IMapper mapper, IValidator<EventCreateApiDTO> eventValidator)
    {
        _mediator = mediator;
        _fileUploadService = fileUploadService;
        _mapper = mapper;
        _eventValidator = eventValidator;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var query = new EventGetAllQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public string GetById(int id)
    {
        return "value";
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromForm] EventCreateApiDTO eventCreateApiDTO)
    {
        // Validate the DTO
        var validationResult = await _eventValidator.ValidateAsync(eventCreateApiDTO);
        if (!validationResult.IsValid) throw new Application.Exceptions.ValidationException(validationResult);

        // Map from ApiDTO to DTO
        var eventCreateDTO = _mapper.Map<EventCreateDTO>(eventCreateApiDTO);

        // Handle single cover image
        if (eventCreateApiDTO.CoverImageFile != null)
        {
            var coverImageData = await _fileUploadService.ReadFileDataAsync(eventCreateApiDTO.CoverImageFile.OpenReadStream());
            var coverImageUrl = await _fileUploadService.UploadFileAsync(coverImageData, eventCreateApiDTO.CoverImageFile.FileName, "images/events");

            eventCreateDTO.CoverImageUrl = coverImageUrl;
        }

        // Send to MediatR
        var command = new EventCreateCommand(eventCreateDTO); 
        var response = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = response }, null);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
