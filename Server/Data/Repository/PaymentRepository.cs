using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketReservationSystem.Server.Context;
using TicketReservationSystem.Server.Data.Repository.Abstraction;
using TicketReservationSystem.Shared.Domain;

namespace TicketReservationSystem.Server.Data.Repository
{
  public class PaymentRepository : IRepository<Payment>
  {
    private readonly MyContext _context;

    public PaymentRepository(MyContext context)
    {
      _context = context;
    }

    public void Delete(int entityId)
    {
      throw new NotImplementedException();
    }

    public Task<Payment> DeleteAsync(int entityId)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
      return await _context.Payments.Include(p => p.Reservation).ToListAsync();
    }

        public async Task<Payment> AddSessionId(int paymentId,string id)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(payment => payment.PaymentId == paymentId);
            if (payment != null) {
                payment.SessionId = id;
                _context.Entry(payment).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return payment;
        }

    public Task<Payment> GetAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Payment Save(Payment entity)
    {
      throw new NotImplementedException();
    }

    public Task<Payment> SaveAsync(Payment entity)
    {
      throw new NotImplementedException();
    }

    public Payment Update(int id, Payment entity)
    {
      throw new NotImplementedException();
    }

    public Task<Payment> UpdateAsync(int id, Payment entity)
    {
      throw new NotImplementedException();
    }
  }
}
