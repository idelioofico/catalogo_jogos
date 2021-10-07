using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using catalogo_jogos.Entities;
using catalogo_jogos.Services;
using catalogo_jogos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace catalogo_jogos.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            this._gameService = gameService;
        }

        /// <summary>
        /// This service gets all available games
        /// </summary>
        /// <returns>Returns status code of 200 and list os Games</returns>
        //[SwaggerResponse(StatusCode:200,ApiDescriptionActionData:"Success")]
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get([FromQuery, Range(1, int.MaxValue)] int page = 1, [FromQuery, Range(5, 500)] int rows = 5)
        {
            return this._gameService.Get(page, rows);
        }

        [HttpPost]
        public ActionResult<GameViewModel> Post([FromBody] GameViewModel gameViewModel)
        {

            try
            {
                var game = this._gameService.Store(gameViewModel);
                return Ok(game);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity("The Game already exists");
            }

        }

        [HttpGet("{id:guid}")]
        public ActionResult<GameViewModel> Get([FromRoute] Guid id)
        {
            var game = this._gameService.Get(id);

            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPut("{id:guid}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] GameViewModel gameViewModel)
        {
            this._gameService.Update(id, gameViewModel);
            return Ok();

        }

        [HttpDelete("{id:guid}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            var game = this._gameService.Get(id);
            if (game == null)
                return NotFound();
            this._gameService.Delete(id);
            return Ok();
        }
    }
}