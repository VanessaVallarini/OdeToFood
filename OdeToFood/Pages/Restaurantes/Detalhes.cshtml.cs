using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurantes
{
    public class DetalhesModel : PageModel
    {
        private readonly IRestauranteData restauranteData;
        public Restaurante Restaurante { get; set; }
        [TempData]
        public string Message { get; set; }

        //injestão de dependência, assim como fizemos em lista
        public DetalhesModel(IRestauranteData restauranteData)
        {
            this.restauranteData = restauranteData;
        }

        //IActionResult me permite brincar com qual página irei retornar
        public IActionResult OnGet(int restauranteId)
        {
            Restaurante = restauranteData.GetById(restauranteId);
            //em vez de retornar a página vamos retornar erro 302
            if (Restaurante == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
