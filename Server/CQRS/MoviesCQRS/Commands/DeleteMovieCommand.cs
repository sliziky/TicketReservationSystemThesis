using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Data.Repository;

namespace TicketReservationSystem.Server.CQRS.Commands
{
    public class DeleteMovieCommand : IRequest { public int Id { get; set; } }
}
