using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace Filterbot.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CommandController : ControllerBase
{
    [HttpPost]
    public IActionResult Webhook([FromBody] Update update)
    {
        return Ok();
    }

    [HttpGet] 
    public IActionResult SetWebhook() => Ok("Ok");
}