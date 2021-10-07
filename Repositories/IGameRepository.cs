using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using catalogo_jogos.Entities;
using catalogo_jogos.ViewModel;

namespace catalogo_jogos.Repositories
{
    public interface IGameRepository : IDisposable
    {
       public List<Game> Get(int page, int rows);
        
      public  Game Store(Game game);
        
        public Game Get(Guid id);

       public Game Get(string name,string producer);

       public void Update(Guid id,Game game);
        
      public  void Delete(Game game);
      public  void Commit();

      

    }
}