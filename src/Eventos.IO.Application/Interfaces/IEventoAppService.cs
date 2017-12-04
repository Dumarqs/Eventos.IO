using Eventos.IO.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Application.Interfaces
{
    public interface IEventoAppService : IDisposable
    {
        void Add(EventoViewModel eventoViewModel);
        IEnumerable<EventoViewModel> GetAll();
        IEnumerable<EventoViewModel> GetByOrganizador(Guid organizadorId);
        EventoViewModel GetById(Guid id);
        void Update(EventoViewModel eventoViewModel);
        void Delete(Guid id);
    }
}
