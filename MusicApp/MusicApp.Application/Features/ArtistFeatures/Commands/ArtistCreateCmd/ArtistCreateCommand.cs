using MediatR;
using MusicApp.Application.DTOs.ArtistDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Application.Features.ArtistFeatures.Commands.ArtistCreateCmd;

public record ArtistCreateCommand(ArtistCreateDTO ArtistCreateDTO) : IRequest<Guid>;
