using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestauranteData : IRestauranteData
    {
        //dados apenas para teste e ambiente de desenvolvimento
        readonly List<Restaurante> restaurantes;

        public InMemoryRestauranteData()
        {
            restaurantes = new List<Restaurante>()
            {
                new Restaurante { Id = 1, Nome = "Scott's Pizza", Localizacao = "Londrina", Cozinha = TipoCozinha.Italiana },
                new Restaurante { Id = 2, Nome = "Cinnamon Club", Localizacao = "Maringa", Cozinha = TipoCozinha.Indiana },
                new Restaurante { Id = 3, Nome = "La Costa", Localizacao = "Cambe", Cozinha = TipoCozinha.Mexicana },
                new Restaurante { Id = 4, Nome = "Bolinha", Localizacao = "Maringa", Cozinha = TipoCozinha.Brasileira },
                new Restaurante { Id = 5, Nome = "Qual meu nome", Localizacao = "Maringa", Cozinha = TipoCozinha.Nenhum }
            };
        }

        public Restaurante GetById(int id)
        {
            //SingleOrDefaultretorna o único restaurante correspondente ao parâmetro recebido ou me dê um valor padrão para restaurante que é nulo
            //r deve ser igual a r.Id, cujo deve ser igual ao id de entrada
            return restaurantes.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurante> GetRestaurantByName(string name=null)//parâmetro se torna opcional
        {
            return from r in restaurantes
                   where string.IsNullOrEmpty(name) || r.Nome.ToLower().Contains(name.ToLower())
            orderby r.Nome
                   select r;
        }

        public Restaurante Update(Restaurante updateRestaurante)
        {
            var restaurante = restaurantes.SingleOrDefault(r => r.Id == updateRestaurante.Id);
            if (restaurante != null)
            {
                restaurante.Nome = updateRestaurante.Nome;
                restaurante.Localizacao = updateRestaurante.Localizacao;
                restaurante.Cozinha = updateRestaurante.Cozinha;
            }

            return restaurante;
        }

        public Restaurante Add(Restaurante newRestaurante)
        {
            restaurantes.Add(newRestaurante);
            newRestaurante.Id = restaurantes.Max(r => r.Id) + 1;
            return newRestaurante;
        }

        public Restaurante Delete(int id)
        {
            var restaurante = restaurantes.FirstOrDefault(r => r.Id == id);
            if (restaurante != null)
            {
                restaurantes.Remove(restaurante);
            }
            return restaurante;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
