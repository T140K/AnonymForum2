using AnonymForum2.Helper;
using AnonymForum2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AnonymForum2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        TopicAPI _api = new TopicAPI();
        public async Task<IActionResult> OnGet()
        {
            List<Topic> topics = new List<Topic>();
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.GetAsync("/api/Topic");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                topics = JsonConvert.DeserializeObject<List<Topic>>(result);
            }

            ViewData["Topics"] = topics;
            return Page();
        }
    }
}