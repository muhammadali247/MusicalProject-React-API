using AutoMapper;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.SongDTOs;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.SongFeatures.Queries.SongGetByIdQry;

public class SongGetByIdQueryHandler : IRequestHandler<SongGetByIdQuery, SongViewDTO>
{
    private readonly ISongRepository _songRepository;
    private readonly IMapper _mapper;

    public SongGetByIdQueryHandler(ISongRepository songRepository, IMapper mapper)
    {
        _songRepository = songRepository;
        _mapper = mapper;
    }

    public async Task<SongViewDTO> Handle(SongGetByIdQuery request, CancellationToken cancellationToken)
    {
        var song = await _songRepository.GetByIdDetailedAsync(request.Id);

        if (song == null) throw new NotFoundException(nameof(Song), request.Id);
        return _mapper.Map<SongViewDTO>(song);
    }
}
