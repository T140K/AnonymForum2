using AnonymForum2.Helper;
using AnonymForum2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace AnonymForum2.Pages
{
    public class ReplyModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int OriginalPostId { get; set; }
        [BindProperty]
        public Reply replyForm { get; set; }

        TopicAPI _api = new TopicAPI();

        public void OnGet()
        {

        }

        //https://localhost:7226/api/Reply/ReplyToPost/4/%3F%3F%3F%3F%3F

        public async Task<IActionResult> OnPostAsync()
        {
            string apiUrl = $"/api/Reply/ReplyToPost/{OriginalPostId}/{replyForm.Contents}";

            string jsonData = JsonConvert.SerializeObject(replyForm);
            HttpClient client = _api.Initial();

            if (string.IsNullOrEmpty(replyForm.Contents))
            {
                return RedirectToPage("/Index");
            }

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Thread", new { OriginalPostId = OriginalPostId });
            }
            return Page();
        }
    }
}
