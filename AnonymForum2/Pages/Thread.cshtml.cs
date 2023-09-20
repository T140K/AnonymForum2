using AnonymForum2.Helper;
using AnonymForum2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace AnonymForum2.Pages
{
    public class ThreadModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public int OriginalPostId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int OriginalTopicId { get; set; }

        TopicAPI _api = new TopicAPI();
        public async Task<IActionResult> OnGet()
        {
            List<Reply> replyList = new List<Reply>();
            List<Post> originalPost = new List<Post>();

            HttpClient client = _api.Initial();
            HttpClient client2 = _api.Initial();

            HttpResponseMessage respGetReplyById = await client.GetAsync($"/api/Reply/GetReplyByPostId/{OriginalPostId}");
            HttpResponseMessage respOriginalPost = await client2.GetAsync($"/api/Post/GetPostById/{OriginalPostId}");



            if (respGetReplyById.IsSuccessStatusCode)
            {
                var result = await respGetReplyById.Content.ReadAsStringAsync();
                replyList = JsonConvert.DeserializeObject<List<Reply>>(result);

            }

            ViewData["replyList"] = replyList;

            if (respOriginalPost.IsSuccessStatusCode)
            {
                var result = await respOriginalPost.Content.ReadAsStringAsync();
                originalPost = JsonConvert.DeserializeObject<List<Post>>(result);

            }

            ViewData["postList"] = originalPost;

            return Page();
        }

    }
}
