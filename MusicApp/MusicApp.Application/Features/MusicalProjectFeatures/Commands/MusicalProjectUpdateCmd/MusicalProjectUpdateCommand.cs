using MediatR;
using MusicApp.Application.DTOs.MusicalProjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.MusicalProjectFeatures.Commands.MusicalProjectUpdateCmd;

public record MusicalProjectUpdateCommand(Guid Id, MusicalProjectUpdateDTO MusicalProjectUpdateDTO) : IRequest<Guid>;

