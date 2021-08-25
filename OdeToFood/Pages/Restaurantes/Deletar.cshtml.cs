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
    public class DeletarModel : PageModel
    {
        private readonly IRestauranteData restauranteData;
        public Restaurante Restaurante { get; set; }

        public DeletarModel(IRestauranteData restauranteData)
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
        public IActionResult OnPost(int restauranteId)
        {
            var restaurante = restauranteData.Delete(restauranteId);
            restauranteData.Commit();
            if (restaurante == null)//se em tempo de execução outro usuário excluiu esse restaurante
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{restaurante.Nome} deletado!";
            return RedirectToPage("./Lista");
        }
    }
}
