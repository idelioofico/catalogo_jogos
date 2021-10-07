using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using catalogo_jogos.Entities;
using catalogo_jogos.ViewModel;

namespace catalogo_jogos.Services
{
    public interface IGameService:IDisposable
    {
        List<Game> Get(int page, int rows);
      
        Game Store(GameViewModel gameViewModel);
      
        Game Get(Guid id);

        Game Get(string name, string producer);
      
        Game Update(Guid id, GameViewModel gameViewModel);
      
        void Delete(Guid id);


    }
}