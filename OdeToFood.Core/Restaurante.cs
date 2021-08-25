using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeToFood.Core
{
    public class Restaurante //: IValidatableObject //permite que eu escreva validações tipo required porém, personalizadas. Mas não vamos usar no momento
    {
        public int Id { get; set; }
        [Required]//isso já valida quando for dar um update: evita que o usuário informe um nome == null
        [StringLength(80)]//tamanho máximo para um nome de restaurante
        public string Nome { get; set; }
        [Required, StringLength(255)]
        public string Localizacao { get; set; }
        public TipoCozinha Cozinha { get; set; }
    }
}
