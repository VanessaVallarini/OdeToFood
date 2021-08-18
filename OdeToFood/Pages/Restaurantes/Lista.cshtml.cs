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
        public string Mensagem { get; set; }
        public IEnumerable<Restaurante> Restaurantes { get; set; }

        //Construtor appsettings
        public ListaModel(IConfiguration config, IRestauranteData restauranteData)
        {
            this.config = config;
            this.restauranteData = restauranteData;
        }

        //Método responsável por responder as requisições HTTP GET
        public void OnGet()
        {
            //Simulando o acesso aos dados
            Mensagem = config["Message"];
            Restaurantes = restauranteData.GetAll();
        }
    }
}
