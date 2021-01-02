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
      return await _context.Users.Include(s => s.Admin).ToListAsync();
    }

    public async Task<User> GetAsync(int id)
    {
      return await _context.Users.Include(user => user.Admin).FirstOrDefaultAsync(user => user.UserId == id && !user.Deleted);
    }

    public async Task<User> GetAsync(string email)
    {
      return await _context.Users.Include(user => user.Admin).FirstOrDefaultAsync(user => user.Email == email && !user.Deleted);
    }

    public User Save(User entity)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> AuthenticateUser(User entity) 
    {
        var user = _context.Users.FirstOrDefault(user => user.Email == entity.Email && !user.Deleted);
        if (user == null) { return false; }
        var hashedPw = BCrypt.Net.BCrypt.HashPassword(entity.Password + user.Salt);
            return BCrypt.Net.BCrypt.Verify(entity.Password + user.Salt, user.Password);
    }
        public async Task<User> ChangePassword(UserChangePassword user) 
        {
            var userFound = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            var authenticated = BCrypt.Net.BCrypt.Verify(user.OldPassword + userFound.Salt, userFound.Password);
            if (!authenticated) { return null; }
            userFound.Password = BCrypt.Net.BCrypt.HashPassword(user.NewPassword + userFound.Salt);
            await _context.SaveChangesAsync();
            return userFound;
        }
    public async Task<User> SaveAsync(User entity)
    {
      var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == entity.Email);
      if (user != null) { return null; }
      var salt = BCrypt.Net.BCrypt.GenerateSalt(6);
      var password = entity.Password + salt;
      entity.Salt = salt;
      entity.Password = BCrypt.Net.BCrypt.HashPassword(password);
      await _context.AddAsync(entity);
      await _context.SaveChangesAsync();
      var admin = _context.Admins.Find(entity.Admin.AdminId);
      await _context.SaveChangesAsync();
      admin.UserId = entity.UserId;
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
        user.Deleted = true;
        await _context.SaveChangesAsync();
      }
      return user;
    }
  }
}
