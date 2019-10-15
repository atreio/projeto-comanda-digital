using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComandaDigital.Enums
{
    public enum TipoUsuario
    {
        [Display(Name = "Gerente")]
        Gerente = 1,
        [Display(Name = "Cliente")]
        Cliente = 2,
        [Display(Name = "Cozinha")]
        Cozinha = 2,
        [Display(Name = "Garçom")]
        Garcom = 2
    }
}
