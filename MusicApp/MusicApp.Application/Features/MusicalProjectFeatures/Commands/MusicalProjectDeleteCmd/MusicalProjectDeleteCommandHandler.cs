using MediatR;
using MusicApp.Application.Abstractions.Repositories;
using MusicApp.Application.Features.ArtistFeatures.Commands.ArtistDeleteCmd;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.MusicalProjectFeatures.Commands.MusicalProjectDeleteCmd;

public class MusicalProjectDeleteCommandHandler : IRequestHandler<MusicalProjectDeleteCommand, Guid>
{
    private readonly IMusicalProjectRepository _musicalProjectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MusicalProjectDeleteCommandHandler(IUnitOfWork unitOfWork, IMusicalProjectRepository musicalProjectRepository)
    {
        _unitOfWork = unitOfWork;
        _musicalProjectRepository = musicalProjectRepository;
    }

    public async Task<Guid> Handle(MusicalProjectDeleteCommand request, CancellationToken cancellationToken)
    {

        var existingMusicalProject = await _musicalProjectRepository.GetByIdDetailedAsync(request.Id);
        if (existingMusicalProject == null) throw new Exceptions.NotFoundException(nameof(MusicalProject), request.Id);

        await _musicalProjectRepository.DeleteAsync(existingMusicalProject.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return existingMusicalProject.Id;
    }
}
