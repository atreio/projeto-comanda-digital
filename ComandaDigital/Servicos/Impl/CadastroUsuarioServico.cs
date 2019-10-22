using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ComandaDigital.Dtos;
using ComandaDigital.Models;
using ComandaDigital.Repositorio;

namespace ComandaDigital.Servicos.Impl
{
    public class CadastroUsuarioServico : ICadastroUsuarioServico
    {
        private readonly IUsuarioRepository usuarioRepository;
        public CadastroUsuarioServico(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public UsuarioDto BuscaUsuarioPorEmailSenha(string email, string senha)
        {
            var usuario = usuarioRepository.GetUsuarioByEmailAndSenha(email, senha);
            return usuario == null ? null : Mapper.Map<UsuarioDto>(usuario);
        }

        public UsuarioDto BuscaUsuarioPorId(int id)
        {
            try
            {
                var usuario = usuarioRepository.GetById(id);
                return usuario == null ? null : Mapper.Map<UsuarioDto>(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EditarUsuario(UsuarioDto dto)
        {
            var usuario = usuarioRepository.GetById(dto.Id);
            if (usuario == null)
                return;

            usuario.EditarUsuario(dto.TipoUsuario, dto.Nome, dto.Email, dto.Senha, dto.Telefone, dto.Cpf);
            usuarioRepository.Update(usuario);
        }

        public void ExcluirUsuario(UsuarioDto dto)
        {
            var usuario = usuarioRepository.GetById(dto.Id);
            if (usuario == null)
                return;

            usuarioRepository.Delete(usuario.Id);
        }

        public UsuarioListDto ListarTodosUsuarios()
        {
            var usuario = usuarioRepository.GetAll();
            var listUsuarioDto = new UsuarioListDto();

            listUsuarioDto.Usuarios = Mapper.Map<List<UsuarioDto>>(usuario.OrderBy(d => d.Nome));
            return listUsuarioDto;
        }
        public void NovoUsuario(UsuarioDto dto)
        {
            var usuario = new Usuario(dto.TipoUsuario, dto.Nome, dto.Email, dto.Senha, dto.Telefone, dto.Cpf);
            usuarioRepository.Create(usuario);
        }
    }
}
