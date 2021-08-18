using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneToFood.Data
{
    public interface IRestauranteData
    {
        IEnumerable<Restaurante> GetAll();
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
                new Restaurante { Id = 4, Nome = "Qual meu nome", Localizacao = "Maringa", Cozinha = TipoCozinha.Nenhum }
            };
        }

        public IEnumerable<Restaurante> GetAll()
        {
            return restaurantes;
        }
    }
}
