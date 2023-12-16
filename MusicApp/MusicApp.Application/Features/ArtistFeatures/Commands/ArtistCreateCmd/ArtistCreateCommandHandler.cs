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

namespace MusicApp.Application.Features.ArtistFeatures.Commands.ArtistCreateCmd;

public class ArtistCreateCommandHandler : IRequestHandler<ArtistCreateCommand, Guid>
{
    private readonly IArtistRepository _artistRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<ArtistCreateDTO> _createValidator;
    private readonly IUnitOfWork _unitOfWork;

    public ArtistCreateCommandHandler(IUnitOfWork unitOfWork, IValidator<ArtistCreateDTO> createValidator, IMapper mapper, IArtistRepository artistRepository)
    {
        _unitOfWork = unitOfWork;
        _createValidator = createValidator;
        _mapper = mapper;
        _artistRepository = artistRepository;
    }

    public async Task<Guid> Handle(ArtistCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request.ArtistCreateDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);

        var newArtist = _mapper.Map<Artist>(request.ArtistCreateDTO);
        newArtist = await _artistRepository.CreateAsync(newArtist);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return newArtist.Id;
    }
}
