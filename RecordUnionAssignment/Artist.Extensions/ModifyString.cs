using Artist.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Artist.Extensions
{
    public class ModifyString
    {


        //Modifies artist name to be able to get the name from the database
        public string stringModifier(Domain.Artist artist)
        {
            var name = artist.ArtistName;
            string correctName;
            correctName = Regex.Replace(name, @"\W", string.Empty).ToLower();

            return correctName;
        }
    }
}
