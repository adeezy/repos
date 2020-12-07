using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistService.Api.Models
{
    public class ArtistModel
    {
         public string ArtistId { get; set; }

        [Required] public string ArtistName { get; set; }
    }
}
