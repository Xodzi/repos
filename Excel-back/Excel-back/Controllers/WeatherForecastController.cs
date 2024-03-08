using Excel_back.Moldes;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Excel_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExcelController : ControllerBase
    {

        private readonly ILogger<ExcelController> _logger;

        public ExcelController(ILogger<ExcelController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Post")]
        public JsonResult Post([FromBody] List<Node> nodes)
        {
            return new JsonResult(nodes);
        }
    }
}