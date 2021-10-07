using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalogo_jogos.Data;
using catalogo_jogos.Entities;
using catalogo_jogos.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace catalogo_jogos.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;

        public GameRepository(ApplicationDbContext context)
        {
            this._context=context;
        }

        public void Delete(Game game)
        {
            _context.Remove(game);
            this.Commit();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public List<Game> Get(int page, int rows)
        {
           return this._context.Games.Skip((page - 1) * rows).Take(rows).ToList();
        }

        public  Game Get(Guid id)
        {
           return this._context.Games.FirstOrDefault(game => game.Id == id);

        }

        public Game Get(string name, string producer)
        {
            return this._context.Games.FirstOrDefault(game => game.Name == name && game.Producer == producer);
        }

        public Game Store(Game game)
        {
            var ts=this._context.Games.Add(game);
            this.Commit();
            return ts.Entity;  
        }

        public void Update(Guid id,Game game)
        {
      
            this.Commit();
        }

        public void Commit() {

           this. _context.SaveChanges();
        }

    
    }
}