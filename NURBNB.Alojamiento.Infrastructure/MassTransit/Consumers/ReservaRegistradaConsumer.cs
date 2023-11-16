﻿using MassTransit;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.ModificarReservaPropiedad;
using NURBNB.IntegrationEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.AgregarReservaPropiedad;

namespace NURBNB.Alojamiento.Infrastructure.MassTransit.Consumers
{
    public class ReservaRegistradaConsumer : IConsumer<ReservaRegistradaEliminar>
    {
        private readonly IMediator _mediator;

        public ReservaRegistradaConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ReservaRegistradaEliminar> context)
        {
            var message = context.Message;
            var command = new AgregarReservaPropiedadCommand
            {
                ReservaId = message.ReservaId,
                FechaEntrada = message.FechaLlegada,
                FechaSalida = message.FechaSalida,
                Estado = Domain.Model.Alojamiento.EstadoReserva.Pendiente
            };
            await _mediator.Send(command);
        }
    }
}
