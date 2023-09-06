using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BookClub.UI.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            this.logger = logger;
        }
        public void OnGet()
        {
            logger.LogInformation("Hello, its logging from the UI!");
        }
    }
}
