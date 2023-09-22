using AnonymForum2.Helper;
using AnonymForum2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace AnonymForum2.Pages
{
    public class CreatePostModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public int TopicId { get; set; }
        [BindProperty]
        public Post newPost { get; set; }

        TopicAPI _api = new TopicAPI();
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string apiUrl = $"/api/Post/NewPost/{newPost.Fktopic}/{newPost.Title}/{newPost.Contents}";

            string jsonData = JsonConvert.SerializeObject(newPost);
            HttpClient client = _api.Initial();

            if (string.IsNullOrEmpty(newPost.Contents) || string.IsNullOrEmpty(newPost.Title))
            {
                return RedirectToPage("/Index");
            }

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Post", new { Id = newPost.Fktopic, Name = Name });
            }
            return Page();
        }
    }
}
