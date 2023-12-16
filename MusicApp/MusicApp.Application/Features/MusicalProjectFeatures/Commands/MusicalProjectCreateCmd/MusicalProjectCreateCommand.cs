using MediatR;
using MusicApp.Application.DTOs.MusicalProjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.MusicalProjectFeatures.Commands.MusicalProjectCreateCmd;

public record MusicalProjectCreateCommand(MusicalProjectCreateDTO MusicalProjectCreateDTO) : IRequest<Guid>;

