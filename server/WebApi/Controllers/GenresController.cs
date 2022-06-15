namespace WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Application.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> logger;
        private IGenreService _genreService;

        public GenresController(ILogger<GenresController> logger, IGenreService genreService)
        {
            this.logger = logger;
            _genreService = genreService;
        }

        [HttpGet]
        public ActionResult<List<GenreDto>> Get()
        {
            try
            {
                var model = _genreService.GetGenres();
                if (model.Count < 1)
                {
                    return NotFound();
                }

                return this.Ok(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception err)
            {
                return Problem(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<GenreDto> Insert([FromBody] GenreCreateRequestDto genre)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return this.Ok(_genreService.InsertGenre(genre));
                }
                catch (Exception err)
                {
                    return Problem(err.Message);
                }
            }

            return BadRequest();
        }

        [HttpPut]
        public ActionResult<GenreDto> Update([FromBody] GenreUpdateRequestDto genre)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return this.Ok(_genreService.UpdateGenre(genre));
                }
                catch (Exception err)
                {
                    return Problem(err.Message);
                }
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<GenreDto> Delete(int id)
        {
            try
            {
                _genreService.DeleteGenre(id);
                return this.NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception err)
            {
                return Problem(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<GenreDto> GetById(int id)
        {
            try
            {
                return this.Ok(_genreService.GetById(id));
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception err)
            {
                return Problem(err.Message);
            }
        }
    }
}