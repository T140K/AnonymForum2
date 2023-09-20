using AnonymForumAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnonymForumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly AnonymForumContext _context;
        public ReplyController(AnonymForumContext context)
        {
            _context = context;
        }

        [HttpGet("GetReplyByPostId/{id}")]
        public async Task<ActionResult<List<Reply>>> GetReplyByID(int id)
        {
            var postReply = await _context.Replies
            .Where(r => r.Fkpost == id)
            .Select(r => new {
                r.Id,
                r.Contents,
                r.ReplyDate
            })
            .ToListAsync();
            return Ok(postReply);
        }

        [HttpPost("ReplyToPost/{FKPost}/{contents}")]
        public async Task<IActionResult> Reply(int FKPost, string contents)
        {
            var existingPost = await _context.Topics
            .FirstOrDefaultAsync(p => p.Id == FKPost);

            if (existingPost == null)
            {
                BadRequest("Post doesnt exist anymore");
            }

            var newReply = new Reply
            {
                Fkpost = FKPost,
                Contents = contents,
                ReplyDate = DateTime.Now
            };

            _context.Replies.Add(newReply);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
