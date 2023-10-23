using Microsoft.AspNetCore.Mvc;
using SaphyreProject.Server.Services;
using SaphyreProject.Shared.Models;

namespace SaphyreProject.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _iUserService;
    public UserController(IUserService iUserService)
    {
        _iUserService = iUserService;
    }
    [HttpGet]
    public async Task<List<User>> Get()
    {
        return await Task.FromResult(_iUserService.GetUserDetails());
    }
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        User user = _iUserService.GetUserData(id);
        if (user != null)
        {
            return Ok(user);
        }
        return NotFound();
    }
    [HttpPost]
    public void Post(User user)
    {
        _iUserService.AddUser(user);
    }
    [HttpPut]
    public void Put(User user)
    {
        _iUserService.UpdateUserDetails(user);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _iUserService.DeleteUser(id);
        return Ok();
    }
}
