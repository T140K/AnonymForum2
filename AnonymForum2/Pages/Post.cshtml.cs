using AnonymForum2.Helper;
using AnonymForum2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnonymForum2.Pages
{
    public class PostModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        TopicAPI _api = new TopicAPI();

        public async Task<IActionResult> OnGet()
        {
            List<Post> posts = new List<Post>();
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync($"/api/Post/GetPostByTopic/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                posts = JsonConvert.DeserializeObject<List<Post>>(result);
            }

            ViewData["Posts"] = posts;

            return Page();
        }
    }
}
