using MediatR;
using MusicApp.Application.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Commands.VerifyAccountCmd;

public record VerifyAccountCommand(string UserId, VerifyAccountDTO VerifyAccountDTO) : IRequest<string>;
