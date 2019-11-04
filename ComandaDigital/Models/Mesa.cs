using ComandaDigital.Models.Base;

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

        public void Editar(string descricao, int quantidade)
        {
            Descricao = descricao;
            Quantidade = quantidade;
        }
    }
}
