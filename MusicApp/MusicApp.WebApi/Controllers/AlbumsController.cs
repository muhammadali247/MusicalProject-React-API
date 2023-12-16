using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Application.Abstractions.Services;
using MusicApp.Application.DTOs.AlbumDTOs;
using MusicApp.Application.Features.AlbumFeatures.Commands.AlbumCreateCmd;
using MusicApp.Application.Features.AlbumFeatures.Queries.AlbumGetAllQry;
using MusicApp.Application.Features.AlbumFeatures.Queries.AlbumGetByIdQry;
using MusicApp.WebApi.DTOs.AlbumApiDTOs;
using System;
using System.Linq;

namespace MusicApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlbumsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IFileUploadService _fileUploadService;
    private readonly IMapper _mapper;
    private readonly IValidator<AlbumCreateApiDTO> _albumValidator;

    public AlbumsController(IMediator mediator, IFileUploadService fileUploadService, IMapper mapper, IValidator<AlbumCreateApiDTO> albumValidator)
    {
        _mediator = mediator;
        _fileUploadService = fileUploadService;
        _mapper = mapper;
        _albumValidator = albumValidator;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var query = new AlbumGetAllQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }




    [HttpGet("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new AlbumGetByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }




    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromForm] AlbumCreateApiDTO albumCreateApiDto)
    {
        var validationResult = await _albumValidator.ValidateAsync(albumCreateApiDto);
        if (!validationResult.IsValid) throw new Application.Exceptions.ValidationException(validationResult);

        var albumCreateDto = _mapper.Map<AlbumCreateDTO>(albumCreateApiDto);

        // Handle images
        if(albumCreateApiDto.AlbumImages != null && albumCreateApiDto.AlbumImages.Any())
        {
            var albumImageDtos = new List<AlbumImageToAddDTO>();
            foreach (var imageDto in albumCreateApiDto.AlbumImages)
            {
                var imageData = await _fileUploadService.ReadFileDataAsync(imageDto.ImageFile.OpenReadStream());
                var imageUrl = await _fileUploadService.UploadFileAsync(imageData, imageDto.ImageFile.FileName, "images/albums");
               
                var albumImageToAddDto = _mapper.Map<AlbumImageToAddDTO>(imageDto);
                albumImageToAddDto.ImageUrl = imageUrl;
                albumImageDtos.Add(albumImageToAddDto);
            }
            albumCreateDto.AlbumImages = albumImageDtos;
        }

        var command = new AlbumCreateCommand(albumCreateDto);
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

    //private string SanitizeFolderName(string folderName)
    //{
    //    // Replace any set of characters that are not allowed in folder names.
    //    string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()) + new string(System.IO.Path.GetInvalidPathChars()));
    //    string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

    //    return System.Text.RegularExpressions.Regex.Replace(folderName, invalidRegStr, "");
    //}
}
