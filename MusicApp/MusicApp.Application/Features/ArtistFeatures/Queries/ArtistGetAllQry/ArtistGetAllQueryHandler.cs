using AutoMapper;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.ArtistDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.ArtistFeatures.Queries.ArtistGetAllQry;

public class ArtistGetAllQueryHandler : IRequestHandler<ArtistGetAllQuery, List<ArtistViewDTO>>
{
    private readonly IArtistRepository _artistRepository;
    private readonly IMapper _mapper;

    public ArtistGetAllQueryHandler(IArtistRepository artistRepository, IMapper mapper)
    {
        _artistRepository = artistRepository;
        _mapper = mapper;
    }


    public async Task<List<ArtistViewDTO>> Handle(ArtistGetAllQuery request, CancellationToken cancellationToken)
    {
        var artists = await _artistRepository.GetAllDetailedAsync();
        return _mapper.Map<List<ArtistViewDTO>>(artists);
    }
}
