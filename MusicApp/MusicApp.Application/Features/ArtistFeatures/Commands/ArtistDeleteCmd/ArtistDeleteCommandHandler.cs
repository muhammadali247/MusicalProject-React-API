using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.ArtistFeatures.Commands.ArtistDeleteCmd;

public class ArtistDeleteCommandHandler : IRequestHandler<ArtistDeleteCommand, Guid>
{
    private readonly IArtistRepository _artistRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ArtistDeleteCommandHandler(IArtistRepository artistRepository, IUnitOfWork unitOfWork)
    {
        _artistRepository = artistRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(ArtistDeleteCommand request, CancellationToken cancellationToken)
    {
        var existingArtist = await _artistRepository.GetByIdDetailedAsync(request.Id);
        if (existingArtist == null) throw new Exceptions.NotFoundException(nameof(Artist), request.Id);

        await _artistRepository.DeleteAsync(existingArtist.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return existingArtist.Id;
    }
}
