using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComandaDigital.Models;
using ComandaDigital.Repositorio;

namespace ComandaDigital.Servicos.Impl
{
    public class SalaoService : ISalaoService
    {
        private readonly IMesaRepository mesaRepository;
        private readonly IPedidoRepository pedidoRepository;

        public SalaoService(IMesaRepository mesaRepository, IPedidoRepository pedidoRepository)
        {
            this.mesaRepository = mesaRepository;
            this.pedidoRepository = pedidoRepository;
        }

        public void AlocarCliente(int mesaId, int garconId, string clienteNome, string clienteDocumento)
        {
            var mesa = mesaRepository.GetById(mesaId);
            var pedido = new Pedido(garconId, clienteDocumento, clienteNome);
            pedidoRepository.Create(pedido);
            mesa.AlocarCliente(pedido);
            mesaRepository.Update(mesa);
        }
    }
}
