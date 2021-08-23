using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OneToFood.Data;

namespace OdeToFood.Pages.Restaurantes
{
    public class EditarModel : PageModel
    {
        private readonly IRestauranteData restauranteData;
        public Restaurante Restaurante{ get; set; }

        public EditarModel(IRestauranteData restauranteData)
        {
            this.restauranteData = restauranteData;
        }

        public IActionResult OnGet(int restauranteId)
        {
            Restaurante = restauranteData.GetById(restauranteId);

            if (Restaurante == null)
            {
                return RedirectToPage("./NotFound");
            }
            
            return Page();
        }
    }
}
