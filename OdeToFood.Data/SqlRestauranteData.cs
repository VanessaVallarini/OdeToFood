using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestauranteData : IRestauranteData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestauranteData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public Restaurante Add(Restaurante newRestaurante)
        {
            db.Add(newRestaurante);
            return newRestaurante;
        }

        public int Commit()
        {
            return db.SaveChanges(); //retorna um int == número de linhas afetadas no banco de dados
        }

        public Restaurante Delete(int id)
        {
            var restaurante = GetById(id);
            if (restaurante != null)
            {
                db.Restaurantes.Remove(restaurante);
            }
            return restaurante;
        }

        public Restaurante GetById(int id)
        {
            return db.Restaurantes.Find(id); //se não encontrar retorna null
        }

        public IEnumerable<Restaurante> GetRestaurantByName(string name)
        {
            if (name != null)
            {
                var query = from r in db.Restaurantes
                            where r.Nome.ToUpper().Contains(name.ToUpper()) || string.IsNullOrEmpty(name)
                            orderby r.Nome
                            select r;
                return query;
            }
            else
            {
                var query = from r in db.Restaurantes
                            select r;
                return query;
            }
        }

        public Restaurante Update(Restaurante updateRestaurante)
        {
            var entity = db.Restaurantes.Attach(updateRestaurante);
            entity.State = EntityState.Modified;
            return updateRestaurante;
        }
    }
}
