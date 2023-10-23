using Microsoft.EntityFrameworkCore;
using SaphyreProject.Server.Models;
using SaphyreProject.Shared.Models;

namespace SaphyreProject.Server.Services;


public interface IUserService
{
    public List<User> GetUserDetails();
    public void AddUser(User user);
    public void UpdateUserDetails(User user);
    public User GetUserData(Guid id);
    public void DeleteUser(Guid id);
}

public class UserService : IUserService
{
    
    readonly UserRepository _dbContext = new();
    
    public UserService(UserRepository dbContext)
    {
        _dbContext = dbContext;
    }
    //To Get all user details
    public List<User> GetUserDetails()
    {
        try
        {
            return _dbContext.Users.ToList();
        }
        catch
        {
            throw;
        }
    }
    
    //To Add new user record
    public void AddUser(User user)
    {
        try
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    
    //To Update the records of a particluar user
    public void UpdateUserDetails(User user)
    {
        Console.Out.Write("******************************" + user.Userid.ToString());
        try
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    
    //Get the details of a particular user
    public User GetUserData(Guid id)
    {
        try
        {
            User? user = _dbContext.Users.Find(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        catch
        {
            throw;
        }
    }
    
    //To Delete the record of a particular user
    public void DeleteUser(Guid id)
    {
        try
        {
            User? user = _dbContext.Users.Find(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        catch
        {
            throw;
        }
    }
}