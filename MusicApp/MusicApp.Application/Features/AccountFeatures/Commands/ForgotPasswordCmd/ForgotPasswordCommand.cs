using MediatR;
using MusicApp.Application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Commands.ForgotPasswordCmd;

public record ForgotPasswordCommand(ForgotPasswordDTO ForgotPasswordDTO) : IRequest<string>;

