using ComandaDigital.Models.Base;
using System.Collections.Generic;

namespace ComandaDigital.Models
{
    public class Mesa : IEntity
    {
        public Mesa() { }

        public Mesa(string numero, string descricao, int quantidade)
        {
            Numero = numero;
            Descricao = descricao;
            Quantidade = quantidade;
        }

        public string Numero { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public bool Ocupada { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual int? PedidoId { get; set; }

        public void AlocarCliente(Pedido pedido)
        {
            Pedido = pedido;
            PedidoId = pedido.Id;
            Ocupada = true;
        }

        public void LiberarMesa()
        {
            Ocupada = false;
            Pedido = null;
            PedidoId = null;
        }
        public void Editar(string numero, string descricao, int quantidade)
        {
            Numero = numero;
            Descricao = descricao;
            Quantidade = quantidade;
        }
    }
}
