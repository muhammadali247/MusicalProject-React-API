using AutoMapper;
using FluentValidation;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Application.DTOs.MusicalProjectDTO;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.MusicalProjectFeatures.Commands.MusicalProjectCreateCmd;

public class MusicalProjectCreateCommandHandler : IRequestHandler<MusicalProjectCreateCommand, Guid>
{
    private readonly IMusicalProjectRepository _musicalProjectRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<MusicalProjectCreateDTO> _createValidator;
    private readonly IUnitOfWork _unitOfWork;

    public MusicalProjectCreateCommandHandler(IMusicalProjectRepository musicalProjectRepository, IMapper mapper, IValidator<MusicalProjectCreateDTO> createValidator, IUnitOfWork unitOfWork)
    {
        _musicalProjectRepository = musicalProjectRepository;
        _mapper = mapper;
        _createValidator = createValidator;
        _unitOfWork = unitOfWork;
    }



    public async Task<Guid> Handle(MusicalProjectCreateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request.MusicalProjectCreateDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);

        var newMusicalProject = _mapper.Map<MusicalProject>(request.MusicalProjectCreateDTO);
        newMusicalProject = await _musicalProjectRepository.CreateAsync(newMusicalProject);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return newMusicalProject.Id;
    }
}
