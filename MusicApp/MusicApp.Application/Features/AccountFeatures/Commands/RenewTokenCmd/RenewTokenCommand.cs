using MediatR;
using MusicApp.Application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Commands.RenewTokenCmd;

public record RenewTokenCommand(RenewTokenDTO RenewTokenDTO) : IRequest<string>;


