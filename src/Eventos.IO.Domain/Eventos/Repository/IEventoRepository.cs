using System;
using Eventos.IO.Domain.Interfaces;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Eventos.Repository
{
    public interface IEventoRepository : IRepository<Evento>
    {
        IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId);
        Endereco ObterEnderecoPorId(Guid id);
        void AddEndereco(Endereco endereco);
        void UpdateEndereco(Endereco endereco);
    }
}