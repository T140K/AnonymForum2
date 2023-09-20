using AnonymForumAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnonymForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly AnonymForumContext _context;
        public PostController(AnonymForumContext context)
        {
            _context = context;
        }

        [HttpGet("GetPostByTopic/{id}")]
        public async Task<ActionResult<List<Post>>> GetPostsByTopicID(int id)
        {
            var postById = await _context.Posts
            .Where(p => p.Fktopic == id)
            .Select(p => new
            {
                p.Id,
                p.Fktopic,
                p.Title,
                p.Contents,
                p.TimePosted
            })
            .ToListAsync();

            return Ok(postById);
        }

        [HttpGet("GetPostById/{id}")]
        public async Task<ActionResult<List<Post>>> GetPostsById(int id)
        {
            var postById = await _context.Posts
            .Where(p => p.Id == id)
            .Select(p => new
            {
                p.Id,
                p.Fktopic,
                p.Title,
                p.Contents,
                p.TimePosted
            })
            .ToListAsync();

            return Ok(postById);
        }

        [HttpPost("NewPost/{PTopic}/{PTitle}/{PContent}")]
        public async Task<IActionResult> NewPost(int PTopic, string PTitle, string PContent)
        {
            var existingTopic = await _context.Topics
            .FirstOrDefaultAsync(t => t.Id == PTopic);

            if(existingTopic == null)
            {
                return BadRequest("Topic doesnt exist");
            }

            var newPost = new Post
            {
                Fktopic = PTopic,
                Title = PTitle,
                Contents = PContent,
                TimePosted = DateTime.Now
            };

            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
