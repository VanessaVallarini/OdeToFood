using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurantes
{
    public class EditarModel : PageModel
    {
        //propriedades da classe que referenciam outros objetos
        private readonly IRestauranteData restauranteData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]//assim a propriedade pode ser tanto entrada quanto sa�da
        public Restaurante Restaurante{ get; set; }
        public IEnumerable<SelectListItem> Cozinhas{ get; set; }

        //htmlHelper traz um objeto da cshtml
        public EditarModel(IRestauranteData restauranteData, IHtmlHelper htmlHelper)
        {
            this.restauranteData = restauranteData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restauranteId) //o ponto de interroga��o torna o restauranteId um par�metro opcional
        {
            //eu poderia fazer essa chamada direto na cshtml, por�m, para futuras altera��es aqui seria melhor
            Cozinhas = htmlHelper.GetEnumSelectList<TipoCozinha>();
            if (restauranteId.HasValue)
            {
                Restaurante = restauranteData.GetById(restauranteId.Value);
            }
            else
            {
                Restaurante = new Restaurante();
            }

            if (Restaurante == null)
            {
                return RedirectToPage("./NotFound");
            }
            
            return Page();
        }

        //assumindo que o id passado no formulario � o ID do restaurante que queremos editar
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) //estou aplicando o que coloquei como valida��o na model Restaurante (ex: [Required])
            {
                Cozinhas = htmlHelper.GetEnumSelectList<TipoCozinha>();
                return Page();
            }

            if (Restaurante.Id > 0)
            {
                restauranteData.Update(Restaurante);
            }
            else
            {
                restauranteData.Add(Restaurante);
            }

            restauranteData.Commit();
            TempData["Message"] = "Restaurante salvo!"; //mensagem tempor�ria
            //post redirect get (PRG) um padr�o de desenvolvimento
            //de forma segura evitamos que o usu�rio atualize uma p�gina post
            //isso poderia ser um problema para post de pagamento com cart�o de cr�dito, eu pagaria 2 x
            return RedirectToPage("./Detalhes", new { restauranteId = Restaurante.Id });
        }
    }
}
