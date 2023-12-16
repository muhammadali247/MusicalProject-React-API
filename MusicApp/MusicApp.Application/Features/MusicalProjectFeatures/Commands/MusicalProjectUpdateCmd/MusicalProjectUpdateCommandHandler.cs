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

namespace MusicApp.Application.Features.MusicalProjectFeatures.Commands.MusicalProjectUpdateCmd;

public class MusicalProjectUpdateCommandHandler : IRequestHandler<MusicalProjectUpdateCommand, Guid>
{
    private readonly IMusicalProjectRepository _musicalProjectRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<MusicalProjectUpdateDTO> _updateValidator;
    private readonly IUnitOfWork _unitOfWork;

    public MusicalProjectUpdateCommandHandler(IMusicalProjectRepository musicalProjectRepository, IMapper mapper, IValidator<MusicalProjectUpdateDTO> updateValidator, IUnitOfWork unitOfWork)
    {
        _musicalProjectRepository = musicalProjectRepository;
        _mapper = mapper;
        _updateValidator = updateValidator;
        _unitOfWork = unitOfWork;
    }



    public async Task<Guid> Handle(MusicalProjectUpdateCommand request, CancellationToken cancellationToken)
    {
        var existingMusicalProject = await _musicalProjectRepository.GetByIdDetailedAsync(request.Id);
        if (existingMusicalProject == null) throw new Exceptions.NotFoundException(nameof(MusicalProject), request.Id);


        var validationResult = await _updateValidator.ValidateAsync(request.MusicalProjectUpdateDTO);
        if (!validationResult.IsValid) throw new Exceptions.ValidationException(validationResult);


        _mapper.Map(request.MusicalProjectUpdateDTO, existingMusicalProject);
        existingMusicalProject = await _musicalProjectRepository.UpdateAsync(request.Id, existingMusicalProject);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return existingMusicalProject.Id;
    }
}
