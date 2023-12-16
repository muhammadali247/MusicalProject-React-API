using MediatR;
using MusicApp.Application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Commands.RegisterCmd;

public record RegisterCommand(RegisterDTO RegisterDTO) : IRequest<string>;

