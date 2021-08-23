using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneToFood.Data
{
    public interface IRestauranteData
    {
        //IEnumerable<Restaurante> GetAll();
        IEnumerable<Restaurante> GetRestaurantByName(string name);
        Restaurante GetById(int id);
    }

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
                   where string.IsNullOrEmpty(name) || r.Nome.StartsWith(name)
            orderby r.Nome
                   select r;
        }
    }
}
