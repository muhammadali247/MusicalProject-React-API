using AutoMapper;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.AlbumDTOs;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AlbumFeatures.Queries.AlbumGetByIdQry;

public class AlbumGetByIdQueryHandler : IRequestHandler<AlbumGetByIdQuery, AlbumViewDTO>
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IMapper _mapper;

    public AlbumGetByIdQueryHandler(IAlbumRepository albumRepository, IMapper mapper)
    {
        _albumRepository = albumRepository;
        _mapper = mapper;
    }
    public async Task<AlbumViewDTO> Handle(AlbumGetByIdQuery request, CancellationToken cancellationToken)
    {
        var album = await _albumRepository.GetByIdDetailedAsync(request.Id);

        if (album == null) throw new NotFoundException(nameof(Album), request.Id);
        return _mapper.Map<AlbumViewDTO>(album);
    }
}
