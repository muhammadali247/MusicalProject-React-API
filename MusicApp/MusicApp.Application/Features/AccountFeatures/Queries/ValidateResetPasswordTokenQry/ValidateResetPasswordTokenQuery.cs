using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.AccountFeatures.Queries.ValidateResetPasswordTokenQry;

public record ValidateResetPasswordTokenQuery(string Email, string Token) : IRequest<string>;
