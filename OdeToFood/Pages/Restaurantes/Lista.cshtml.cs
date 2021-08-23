using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OneToFood.Data;

namespace OdeToFood.Pages.Restaurantes
{
    public class ListaModel : PageModel
    {
        //propriedade privada da classe Lista
        private readonly IConfiguration config;
        //propriedade privada do serviço que traz os dados
        private readonly IRestauranteData restauranteData;

        //propriedade pública da classe Lista
        public IEnumerable<Restaurante> Restaurantes { get; set; }
        [BindProperty(SupportsGet =true)] //ao invés de SearchTerm = searchTerm; uso essa propriedade como meio de entrada e saída, ou seja, ela recebe a solicitação http e retorna o valor determinado por mim via código
        public string SearchTerm { get; set; }

        //Construtor appsettings
        public ListaModel(IConfiguration config, IRestauranteData restauranteData)
        {
            this.config = config;
            this.restauranteData = restauranteData;
        }

        //Método responsável por responder as requisições HTTP GET
        public void OnGet()
        {
            //SearchTerm = searchTerm;
            Restaurantes = restauranteData.GetRestaurantByName(SearchTerm);
        }
    }
}
