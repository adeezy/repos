using ArtistService.Domain;
using MediatR;

namespace ArtistService.Service.Command
{
    public class CreateArtistCommand : IRequest<Artist>
    {
        public Artist Artist { get; set; }

    }
}
