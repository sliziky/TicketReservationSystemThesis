using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Context;

namespace TicketReservationSystem.Server.Extensions
{
  public static class Extensions
  {
    public static void DeleteAll<T>(this MyContext context)
        where T : class
    {
      foreach (var p in context.Set<T>())
      {
        context.Entry(p).State = EntityState.Deleted;
      }
    }
  }
}
