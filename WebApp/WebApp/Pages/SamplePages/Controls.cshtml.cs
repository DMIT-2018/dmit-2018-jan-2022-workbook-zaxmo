using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.SamplePages
{
    public class ControlsModel : PageModel
    {
        [TempData]
        public string Feedback { get; set; }

        public string EmailText { get; set; }

        public string PasswordText { get; set; }

        public DateTime DateText { get; set; } = DateTime.Today;

        public TimeSpan TimeText { get; set; } = DateTime.Now.TimeOfDay;


        public void OnGet()
        {
        }
        
        public IActionResult OnPostTextBox()
        {
            Feedback = $"Email {EmailText}; Password {PasswordText}; Date {DateText}; Time {TimeText};";
            return Page(); 
        }
    }
}
