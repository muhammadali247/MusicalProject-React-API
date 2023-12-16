using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.MusicalProjectFeatures.Commands.MusicalProjectDeleteCmd;

public record MusicalProjectDeleteCommand(Guid Id) : IRequest<Guid>;

