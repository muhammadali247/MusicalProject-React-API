using AutoMapper;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Application.DTOs.MusicalProjectDTO;
using MusicApp.Application.Features.ArtistFeatures.Queries.ArtistGetAllQry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.MusicalProjectFeatures.Queries.MusicalProjectGetAllQry;

public class MusicalProjectGetAllQueryHandler : IRequestHandler<MusicalProjectGetAllQuery, List<MusicalProjectViewDTO>>
{
    private readonly IMusicalProjectRepository _musicalProjectRepository;
    private readonly IMapper _mapper;

    public MusicalProjectGetAllQueryHandler(IMapper mapper, IMusicalProjectRepository musicalProjectRepository)
    {
        _mapper = mapper;
        _musicalProjectRepository = musicalProjectRepository;
    }

    public async Task<List<MusicalProjectViewDTO>> Handle(MusicalProjectGetAllQuery request, CancellationToken cancellationToken)
    {
        var musicalProjects = await _musicalProjectRepository.GetAllDetailedAsync();
        return _mapper.Map<List<MusicalProjectViewDTO>>(musicalProjects);
    }
}
