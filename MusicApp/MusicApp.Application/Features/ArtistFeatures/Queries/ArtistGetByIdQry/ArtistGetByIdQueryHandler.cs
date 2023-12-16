using AutoMapper;
using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.DTOs.ArtistDTOs;
using MusicApp.Application.Exceptions;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.ArtistFeatures.Queries.ArtistGetByIdQry;

public class ArtistGetByIdQueryHandler : IRequestHandler<ArtistGetByIdQuery, ArtistViewDTO>
{
    private readonly IArtistRepository _artistRepository;
    private readonly IMapper _mapper;

    public ArtistGetByIdQueryHandler(IArtistRepository artistRepository, IMapper mapper)
    {
        _artistRepository = artistRepository;
        _mapper = mapper;
    }
    public async Task<ArtistViewDTO> Handle(ArtistGetByIdQuery request, CancellationToken cancellationToken)
    {
        var artist = await _artistRepository.GetByIdDetailedAsync(request.Id);

        if (artist == null) throw new NotFoundException(nameof(Artist), request.Id);
        return _mapper.Map<ArtistViewDTO>(artist);
    }
}
