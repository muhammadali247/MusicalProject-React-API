using MediatR;
using MusicApp.Application.DTOs.AccountDTOs;
using MusicApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Commands.LoginCmd;

public record LoginResponse(string AccessToken, RefreshToken RefreshToken);

public record LoginCommand(LoginDTO LoginDTO) : IRequest<LoginResponse>;

