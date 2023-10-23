using Microsoft.EntityFrameworkCore;
using SaphyreProject.Server.Models;
using SaphyreProject.Shared.Models;
using LogLevel = SaphyreProject.Shared.Models.LogLevel;

namespace SaphyreProject.Server.Services;


public interface IUserService
{
    public List<User> GetUserDetails();
    public void AddUser(User user);
    public void UpdateUserDetails(User user);
    public User GetUser(Guid id);
    public void DeleteUser(Guid id);
}

public class UserService : IUserService
{
    
    private UserRepository userRepository;
    private ILogService logService;
    
    public UserService(UserRepository userRepository, ILogService logService)
    {
        this.userRepository = userRepository;
        this.logService = logService;
    }
    
    //Gets all User details present in DB
    public List<User> GetUserDetails()
    {
        return userRepository.GetUserDetails();
    }
    
    //Adds a new User to the DB
    public void AddUser(User user)
    {
        userRepository.AddUser(user);
        logService.SaveLog(LogLevel.Info, "Successfully created new User: " + user.Userid, "UserService.cs");
    }
    
    //Updates one User
    public void UpdateUserDetails(User user)
    {
        userRepository.UpdateUserDetails(user);
        logService.SaveLog(LogLevel.Info, "Successfully updated User: " + user.Userid, "UserService.cs");
    }
    
    //Gets a single User by Id
    public User GetUser(Guid id)
    {
        return userRepository.GetUser(id);
    }
    
    //Deletes a single User by Id
    public void DeleteUser(Guid id)
    {
        userRepository.DeleteUser(id);
        logService.SaveLog(LogLevel.Info, "Successfully deleted User: " + id, "UserService.cs");
    }
}