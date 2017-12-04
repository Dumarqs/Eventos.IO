using System;
using System.Collections.Generic;
using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Core.Bus;
using AutoMapper;
using Eventos.IO.Domain.Eventos.Commands;
using Eventos.IO.Domain.Eventos.Repository;

namespace Eventos.IO.Application.Services
{
    class EventoAppService : IEventoAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IEventoRepository _eventoRepository;

        public EventoAppService(IBus bus, IMapper mapper, IEventoRepository eventoRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _eventoRepository = eventoRepository;
        }

        public void Add(EventoViewModel eventoViewModel)
        {
            var addCommand = _mapper.Map<RegistrarEventoCommand>(eventoViewModel);
            _bus.SendCommand(addCommand);
        }

        public void Update(EventoViewModel eventoViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarEventoCommand>(eventoViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Delete(Guid id)
        {
            _bus.SendCommand(new ExcluirEventoCommand(id));
        }

        public IEnumerable<EventoViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.GetAll());
        }

        public EventoViewModel GetById(Guid id)
        {
            return _mapper.Map<EventoViewModel>(_eventoRepository.GetById(id));
        }

        public IEnumerable<EventoViewModel> GetByOrganizador(Guid organizadorId)
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.ObterEventoPorOrganizador(organizadorId));
        }

        public void Dispose()
        {
            _eventoRepository.Dispose();
        }
    }
}
