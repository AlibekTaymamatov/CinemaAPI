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
    public class FilmsController : ControllerBase
    {
        private readonly ILogger<FilmsController> logger;
        private IFilmService _filmService;

        public FilmsController(ILogger<FilmsController> logger, IFilmService filmService)
        {
            this.logger = logger;
            _filmService = filmService;
        }

        [HttpGet]
        public ActionResult<List<FilmDto>> Get([FromQuery] FilmsParameters filmsParameters)
        {
            try
            {
                if (!filmsParameters.ValidRatingRange)
                {
                    return BadRequest();
                }

                var model = _filmService.GetFilms(filmsParameters);
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
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<FilmDto> Insert([FromBody] FilmCreateRequestDto film)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return this.Ok(_filmService.InsertFilm(film));
                }
                catch (Exception err)
                {
                    return Problem(err.Message);
                }
            }

            return BadRequest();
        }

        [HttpPut]
        public ActionResult<FilmDto> Update([FromBody] FilmUpdateRequestDto film)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return this.Ok(_filmService.UpdateFilm(film));
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<FilmDto> Delete(int id)
        {
            try
            {
                _filmService.DeleteFilm(id);
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
        public ActionResult<FilmDto> GetById(int id)
        {
            try
            {
                return this.Ok(_filmService.GetById(id));
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