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
  public class UserRepository : IRepository<User>
  {
    private readonly MyContext _context;
    public UserRepository(MyContext context)
    {
      _context = context;
    }

    public void Delete(int entityId)
    {
      throw new NotImplementedException();
    }


    public async Task<IEnumerable<User>> GetAllAsync()
    {
      return await _context.Users.ToListAsync();
    }

    public async Task<User> GetAsync(int id)
    {
      return await _context.Users.FirstOrDefaultAsync(user => user.UserId == id);
    }

    public async Task<User> GetAsync(string email)
    {
      return await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public User Save(User entity)
    {
      throw new NotImplementedException();
    }

    public async Task<User> SaveAsync(User entity)
    {
      var salt = BCrypt.Net.BCrypt.GenerateSalt(6);
      var password = entity.Password + salt;
      entity.Salt = salt;
      entity.Password = BCrypt.Net.BCrypt.HashPassword(password);
      await _context.AddAsync(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public User Update(int id, User entity)
    {
      throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(int id, User entity)
    {
      throw new NotImplementedException();
    }

    public async Task<User> DeleteAsync(int entityId)
    {
      var user = _context.Users.FirstOrDefault(user => user.UserId == entityId);
      if (user != null) {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
      }
      return user;
    }
  }
}
