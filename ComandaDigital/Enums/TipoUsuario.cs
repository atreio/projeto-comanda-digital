using System.ComponentModel.DataAnnotations;

namespace ComandaDigital.Enums
{
    public enum TipoUsuario
    {
        [Display(Name = "Gerente")]
        Gerente = 1,
        [Display(Name = "Cliente")]
        Cliente = 2,
        [Display(Name = "Cozinha")]
        Cozinha = 3,
        [Display(Name = "Garçom")]
        Garcom = 4
    }
}
