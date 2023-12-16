using AutoMapper;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Application.DTOs.SongDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.SongFeatures.Queries.SongGetAllQry;

public class SongGetAllQueryHandler : IRequestHandler<SongGetAllQuery, List<SongViewDTO>>
{
    private readonly ISongRepository _songRepository;
    private readonly IMapper _mapper;

    public SongGetAllQueryHandler(ISongRepository songRepository, IMapper mapper)
    {
        _songRepository = songRepository;
        _mapper = mapper;
    }

    public async Task<List<SongViewDTO>> Handle(SongGetAllQuery request, CancellationToken cancellationToken)
    {
        var songs = await _songRepository.GetAllDetailedAsync();
        return _mapper.Map<List<SongViewDTO>>(songs);
    }
}
