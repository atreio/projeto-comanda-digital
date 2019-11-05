using ComandaDigital.Enums;
using ComandaDigital.Models.Base;
using System.Collections.Generic;

namespace ComandaDigital.Models
{
    public class Usuario : IEntity
    {
        public Usuario() { }
        public Usuario(TipoUsuario tipoUsuario, string nome, string email, string senha, string telefone, string cpf)
        {
            TipoUsuario = tipoUsuario;
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            Cpf = cpf;
        }
        public TipoUsuario TipoUsuario{ get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public List<ItemPedido> ItensPedidos { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public void EditarUsuario(TipoUsuario tipoUsuario, string nome, string email, string senha, string telefone, string cpf)
        {
            TipoUsuario = tipoUsuario;
            Nome = nome;
            Email = email;
            Senha = string.IsNullOrEmpty(senha) ? Senha : senha;
            Telefone = telefone;
            Cpf = cpf;
        }
    }
}
