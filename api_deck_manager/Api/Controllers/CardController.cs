using Microsoft.AspNetCore.Mvc;

namespace api_deck_manager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        public CardController()
        {
        }

        [HttpGet(Name = "GetCard")]
        public string Get()
        {
            return "Card Route";
        }
    }
}
