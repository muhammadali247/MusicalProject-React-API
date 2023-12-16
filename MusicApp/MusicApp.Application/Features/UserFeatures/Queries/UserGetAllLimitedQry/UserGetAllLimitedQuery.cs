using MediatR;
using MusicApp.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.UserFeatures.Queries.UserGetAllLimitedQry;

public record UserGetAllLimitedQuery : IRequest<List<UserViewDTO>>;

