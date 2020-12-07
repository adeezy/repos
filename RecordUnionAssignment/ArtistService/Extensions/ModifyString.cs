using ArtistService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArtistService.Extensions
{
    public class ModifyString
    {


        //Modifies artist name to be able to get the name from the database
        public string stringModifier(Artist artist)
        {
            var name = artist.ArtistName;
            string correctName;
            correctName = Regex.Replace(name, @"\W", string.Empty).ToLower();

            return correctName;
        }
    }
}
