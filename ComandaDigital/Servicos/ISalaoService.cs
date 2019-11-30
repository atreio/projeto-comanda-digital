using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComandaDigital.Servicos
{
    public interface ISalaoService
    {
        void AlocarCliente(int mesaId, int garconId, string clienteNome, string clienteDocumento);
    }
}