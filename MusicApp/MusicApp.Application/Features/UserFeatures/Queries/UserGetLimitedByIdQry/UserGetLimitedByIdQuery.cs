using MediatR;
using MusicApp.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.UserFeatures.Queries.UserGetLimitedByIdQry;

public record UserGetLimitedByIdQuery(string Id) : IRequest<UserViewDTO>;

