using AutoMapper;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.AlbumDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AlbumFeatures.Queries.AlbumGetAllQry;

public class AlbumGetAllQueryHandler : IRequestHandler<AlbumGetAllQuery, List<AlbumViewDTO>>
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IMapper _mapper;

    public AlbumGetAllQueryHandler(IAlbumRepository albumRepository, IMapper mapper)
    {
        _albumRepository = albumRepository;
        _mapper = mapper;
    }

    public async Task<List<AlbumViewDTO>> Handle(AlbumGetAllQuery request, CancellationToken cancellationToken)
    {
        var albums = await _albumRepository.GetAllDetailedAsync();
        return _mapper.Map<List<AlbumViewDTO>>(albums);
    }
}
