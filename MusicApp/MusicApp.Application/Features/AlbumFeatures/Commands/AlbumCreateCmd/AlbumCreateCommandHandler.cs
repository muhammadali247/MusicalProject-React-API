using AutoMapper;
using FluentValidation;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.AlbumDTOs;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AlbumFeatures.Commands.AlbumCreateCmd;

public class AlbumCreateCommandHandler : IRequestHandler<AlbumCreateCommand, Guid>
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<AlbumCreateDTO> _createValidator;
    private readonly IUnitOfWork _unitOfWork;

    public AlbumCreateCommandHandler(IAlbumRepository albumRepository, IMapper mapper, IValidator<AlbumCreateDTO> createValidator, IUnitOfWork unitOfWork)
    {
        _albumRepository = albumRepository;
        _mapper = mapper;
        _createValidator = createValidator;
        _unitOfWork = unitOfWork;
    }


    public async Task<Guid> Handle(AlbumCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request.AlbumCreateDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);

        var newAlbum = _mapper.Map<Album>(request.AlbumCreateDTO);
        newAlbum = await _albumRepository.CreateAsync(newAlbum);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _albumRepository.AssignMainCoverImage(newAlbum.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return newAlbum.Id;
    }
}
