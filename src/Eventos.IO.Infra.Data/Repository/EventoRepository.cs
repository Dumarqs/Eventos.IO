using System;
using System.Collections.Generic;
using Eventos.IO.Domain.Eventos;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Infra.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Eventos.IO.Infra.Data.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(EventosContext context) : base(context)
        {

        }
        public void AddEndereco(Endereco endereco)
        {
            Db.Enderecos.Add(endereco);
        }

        public Endereco ObterEnderecoPorId(Guid id)
        {
            return Db.Enderecos.Find(id);
        }

        public IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId)
        {
            return Db.Eventos.Where(e => e.OrganizadorId == organizadorId);
        }

        public void UpdateEndereco(Endereco endereco)
        {
            Db.Enderecos.Update(endereco);
        }

        public override Evento GetById(Guid id)
        {
            return Db.Eventos.Include(e => e.Endereco).FirstOrDefault(e => e.Id == id);
        }
    }
}
