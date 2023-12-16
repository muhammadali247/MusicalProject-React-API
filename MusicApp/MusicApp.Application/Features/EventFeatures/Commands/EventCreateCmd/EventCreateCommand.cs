using MediatR;
using MusicApp.Application.DTOs.EventDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.EventFeatures.Commands.EventCreateCmd;

public record EventCreateCommand(EventCreateDTO EventCreateDTO) : IRequest<Guid>;


