using Artist.Domain;
using MediatR;

namespace Artist.Service.Command
{
    public class CreateArtistCommand : IRequest<Domain.Artist>
    {
        public Domain.Artist Artist { get; set; }

    }
}
