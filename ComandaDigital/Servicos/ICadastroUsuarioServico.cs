using ComandaDigital.Dtos;

namespace ComandaDigital.Servicos
{
    public interface ICadastroUsuarioServico
    {
        void NovoUsuario(UsuarioDto dto);
        void EditarUsuario(UsuarioDto dto);
        UsuarioDto BuscaUsuarioPorId(int id);
        UsuarioListDto ListarTodosUsuarios();
        UsuarioDto BuscaUsuarioPorEmailSenha(string email, string senha);
    }
}
