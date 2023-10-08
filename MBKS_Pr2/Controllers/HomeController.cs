using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using MBKS_Pr2.Models;
using MBKS_Pr2.Models.Repository;

namespace MBKS_Pr2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserRepo _user;
    
    public HomeController(ILogger<HomeController> logger, UserRepo user)
    {
        _logger = logger;
        _user = user;
    }

    public IActionResult Index()
    {
        var users = _user.GetUsers();
        var uservm = new UserVm();
        uservm.Users = users;
        users=users.OrderByDescending(u => u.Symbols.Count()).ToList();
        uservm.MaxSymbols = users[0].Symbols.Count();
        return View(uservm);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserVm newUser)
    {
        var user=_user.Add(newUser.Name,newUser.Symbols);
        if (user!=null)
        {
            return Ok(user);
        }

        return BadRequest();
    }
    
    [HttpPost]
    public IActionResult ChangeSymbol([FromBody]ChangeSymbolVm changeSymbolVm)
    {
        _user.UpdateSymbol(changeSymbolVm.UserId, changeSymbolVm.SId, changeSymbolVm.Value);
        return RedirectToAction("Index");
    }
    
    [HttpDelete]
    public IActionResult DeleteUser([FromBody] UserDeleteVm userId)
    {
        var res=_user.RemoveUser(userId.UserId);

        if (res)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
    
}