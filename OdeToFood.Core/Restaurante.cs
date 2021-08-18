using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Core
{
    public class Restaurante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public TipoCozinha Cozinha { get; set; }
    }
}
