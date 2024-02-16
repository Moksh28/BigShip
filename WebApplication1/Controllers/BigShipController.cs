using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BigShipController : ControllerBase
    {
        private readonly ILogger<BigShipController> _logger;
        private readonly IChanellService _chanellService;

        public BigShipController(ILogger<BigShipController> logger, IChanellService chanellService)
        {
            _logger = logger;
            _chanellService = chanellService;
        }

        [HttpGet("get-all-permitted-channels")]
        public async Task<IActionResult> GetAllPermittedChannels()
        {
            var channels = await _chanellService.GetChannelsAsync();
            if (channels == null || !channels.Any())
            {
                return NotFound();
            }
            return Ok(channels);
        }

        [HttpGet("get-all-channels-by-id")]
        public async Task<IActionResult> GetAllChannelsById(int user_id)
        {
            var channels = await _chanellService.GetChannelById(user_id);
            if (channels == null || !channels.Any())
            {
                return NotFound();
            }
            return Ok(channels);
        }
    }
}
