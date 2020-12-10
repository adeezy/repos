using Artist.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artist.Extensions
{
    public class SpotifyUri
    {
        ModifyString modifyString = new ModifyString();

        //creates an artist uri for the SpotifyApi
       public string GetArtistUri(Domain.Artist request)
        {
            string apiAdress = "https://api.spotify.com/v1/search?q=";
            string limit = "limit=1";
            string artist = modifyString.stringModifier(request);
            string type = "&type=artist&";


            string uri = apiAdress + artist + type + limit;

            return uri;
        }
    }
}
