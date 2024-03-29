﻿using ComandaDigital.Enums;
using System.Collections.Generic;

namespace ComandaDigital.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
    }

    public class UsuarioListDto
    {
        public List<UsuarioDto> Usuarios { get; set; }
    }
}
