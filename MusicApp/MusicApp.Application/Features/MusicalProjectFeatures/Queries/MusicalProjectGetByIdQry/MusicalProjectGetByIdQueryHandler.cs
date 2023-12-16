using AutoMapper;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Application.DTOs.MusicalProjectDTO;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.MusicalProjectFeatures.Queries.MusicalProjectGetByIdQry;

public class MusicalProjectGetByIdQueryHandler : IRequestHandler<MusicalProjectGetByIdQuery, MusicalProjectViewDTO>
{
    private readonly IMusicalProjectRepository _musicalProjectRepository;
    private readonly IMapper _mapper;

    public MusicalProjectGetByIdQueryHandler(IMapper mapper, IMusicalProjectRepository musicalProjectRepository)
    {
        _mapper = mapper;
        _musicalProjectRepository = musicalProjectRepository;
    }
    public async Task<MusicalProjectViewDTO> Handle(MusicalProjectGetByIdQuery request, CancellationToken cancellationToken)
    {
        var musicalProject = await _musicalProjectRepository.GetByIdDetailedAsync(request.Id);

        if (musicalProject == null) throw new NotFoundException(nameof(MusicalProject), request.Id);
        return _mapper.Map<MusicalProjectViewDTO>(musicalProject);
    }
}
