using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.ArtistFeatures.Commands.ArtistDeleteCmd;

public record ArtistDeleteCommand(Guid Id) : IRequest<Guid>;

