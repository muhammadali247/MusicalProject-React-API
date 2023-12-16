using AutoMapper;
using FluentValidation;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.ArtistFeatures.Commands.ArtistUpdateCmd;

public class ArtistUpdateCommandHandler : IRequestHandler<ArtistUpdateCommand, Guid>
{
    private readonly IArtistRepository _artistRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<ArtistUpdateDTO> _updateValidator;
    private readonly IUnitOfWork _unitOfWork;

    public ArtistUpdateCommandHandler(IUnitOfWork unitOfWork, IValidator<ArtistUpdateDTO> updateValidator, IMapper mapper, IArtistRepository artistRepository)
    {
        _unitOfWork = unitOfWork;
        _updateValidator = updateValidator;
        _mapper = mapper;
        _artistRepository = artistRepository;
    }

    public async Task<Guid> Handle(ArtistUpdateCommand request, CancellationToken cancellationToken)
    {
        var existingArtist = await _artistRepository.GetByIdDetailedAsync(request.Id);
        if (existingArtist == null) throw new Exceptions.NotFoundException(nameof(Artist), request.Id);


        var validationResult = await _updateValidator.ValidateAsync(request.ArtistUpdateDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);


        _mapper.Map(request.ArtistUpdateDTO, existingArtist);
        existingArtist = await _artistRepository.UpdateAsync(request.Id, existingArtist);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return existingArtist.Id;
    }
}
