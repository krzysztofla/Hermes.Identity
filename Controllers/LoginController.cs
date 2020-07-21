using Hermes.Identity.Command.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hermes.Identity.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody]LoginUser command)
        //{
        //    command.TokenId = Guid.NewGuid();
        //    await SendAsync(command);
        //    //var jwt = _cache.GetJwt(command.TokenId);

        //    return Json("jwt");
        //}
    }
}