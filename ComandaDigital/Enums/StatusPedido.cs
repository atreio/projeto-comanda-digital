using System.ComponentModel.DataAnnotations;

namespace ComandaDigital.Enums
{
    public enum StatusPedido
    {
        [Display(Name = "Pedido Realizado")]
        PedidodRealizado = 1,
        [Display(Name = "Em Andamento")]
        EmAndamento = 2,
        [Display(Name = "Concluido")]
        Concluido = 3,
    }
}
