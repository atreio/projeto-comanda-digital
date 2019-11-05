using ComandaDigital.Models.Base;
using System.Collections.Generic;

namespace ComandaDigital.Models
{
    public class Mesa : IEntity
    {
        public Mesa() { }

        public Mesa(string descricao, int quantidade)
        {
            Descricao = descricao;
            Quantidade = quantidade;
        }

        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public List<ItemPedido> ItensPedidos { get; set; }

        public void Editar(string descricao, int quantidade)
        {
            Descricao = descricao;
            Quantidade = quantidade;
        }
    }
}
