using ArtistService.Api.Models;
using ArtistService.Domain;
using ArtistService.Service.Command;
using ArtistService.Service.Query;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArtistService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]


    public class ArtistController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ArtistController(IMapper mapper, IMediator mediator)
        {
            //db = new ArtistContext();
            _mapper = mapper;
            _mediator = mediator;

        }
        // GET: api/<ArtistController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<Artist>> Artist(ArtistModel artistModel)
        {
            try
            {
                return await _mediator.Send(new CreateArtistCommand
                {
                    Artist = _mapper.Map<Artist>(artistModel)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<Artist>> Artists(Artist request)
        {
            try
            {
                Artist artist = new Artist();
                artist = await _mediator.Send(new GetArtistQuery(request));

                    return new JsonResult(artist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }
    }
}


        




