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
    public class AdminRepository : IRepository<Admin>
    {
        private readonly MyContext _context;

        public AdminRepository(MyContext context)
        {
            _context = context;
        }
        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _context.Admins.ToListAsync();
        }
        public async Task<bool> IsUserAdmin(int userId)
        {
            var user = await _context.Admins.FirstOrDefaultAsync(admin => admin.UserId == userId);
            return user != null;
        }
        public Task<Admin> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Admin Save(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> SaveAsync(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Admin Update(int id, Admin entity)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> UpdateAsync(int id, Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
