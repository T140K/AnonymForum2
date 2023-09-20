using AnonymForumAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnonymForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly AnonymForumContext _context;

        public TopicController(AnonymForumContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Topic>>> GetTopics()
        {
            var topics = await _context.Topics
                .Select(t => new
                {
                    t.Id,
                    t.Name
                })
                .ToListAsync();
            return Ok(topics);    
        }
    }
}
