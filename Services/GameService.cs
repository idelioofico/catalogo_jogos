using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using catalogo_jogos.Entities;
using catalogo_jogos.Repositories;
using catalogo_jogos.ViewModel;
using catalogo_jogos.Exceptions;
using System.Linq;

namespace catalogo_jogos.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            this._gameRepository = gameRepository;
        }

        public List<Game> Get(int page, int rows)
        {
         return this._gameRepository.Get(page,rows);

        }
        

        public Game Get(Guid id)
        { 
            var game = this._gameRepository.Get(id);

            if (game != null)
                return game;
            return null;
        }

        public  Game Get(string name, string producer)
        {
          return  this._gameRepository.Get(name, producer);
        }

        public  Game Store(GameViewModel gameViewModel)
        {
            var game =  this._gameRepository.Get(gameViewModel.Name, gameViewModel.Producer);

            if (game == null)
            {
                var gameModel = new Game()
                {
                    Name = gameViewModel.Name,
                    Producer = gameViewModel.Producer,
                    Price = gameViewModel.Price
                };

                return  this._gameRepository.Store(gameModel);
            }
            throw new AlreadyExistsException();

        }

        public Game Update(Guid id, GameViewModel gameViewModel)
        {
            var game = this._gameRepository.Get(id);
            if (game != null)
            {
                var toUpdate = new Game()
                {
                    Id=game.Id,
                    Name=gameViewModel.Name,
                    Producer=gameViewModel.Producer,
                    Price=gameViewModel.Price,
                };
                this._gameRepository.Update(id,toUpdate);
            }

            return game;
        }

        public void Delete(Guid id)
        {
            var game =  this._gameRepository.Get(id);
            if (game != null)
                this._gameRepository.Delete(game);
        }

        public void Dispose()
        {
            this._gameRepository.Dispose();
        }

       
    }
}