using System.Runtime.InteropServices.JavaScript;
using MBKS_Pr2.Models;
using MBKS_Pr2.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MBKS_Pr2.Controllers;

public class MessageController:Controller
{
    private readonly UserRepo _user;

    public MessageController(UserRepo user)
    {
        _user = user;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetText([FromBody]MsgVm message)
    {
        var users = _user.GetUsers();
        var messages = new List<MessageVm>();

        foreach (var user in users)
        {
            var msg = new MessageVm();
            msg.User = user.Name;
            msg.Symbols = new string(user.Symbols.Select(u => u.S).ToArray());
            var t = message.Message.Select(u => u).Where(u => user.Symbols.Exists(x => x.S == u)).ToArray();
            msg.Text = new string(t);
            messages.Add(msg);
        }
        
        return Ok(messages);
    }
}