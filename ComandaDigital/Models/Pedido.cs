using ComandaDigital.Models.Base;
using System.Collections.Generic;
using System.Linq;

namespace ComandaDigital.Models
{
    public class Pedido : IEntity
    {
        public Pedido() { }

        public Pedido(int garcomId, string clienteDocumento, string clienteNome)
        {
            GarcomId = garcomId;
            ItensPedidos = new List<ItemPedido>();
            EmAberto = true;
            ClienteDocumento = clienteDocumento;
            ClienteNome = clienteNome;
        }

        public virtual int GarcomId { get; set; }
        public virtual Usuario Garcom { get; set; }
        public virtual List<ItemPedido> ItensPedidos { get; set; }
        public bool EmAberto { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteDocumento { get; set; }

        public decimal ValorTotal()
        {
            var valorTotal = ItensPedidos.Sum(i => i.Produto.ValorVenda * i.Quantidade);
            return valorTotal;
        }

        public void EncerrarConta()
        {
            EmAberto = false;
        }

    }
}
