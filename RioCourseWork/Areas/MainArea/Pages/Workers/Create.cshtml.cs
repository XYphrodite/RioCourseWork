using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RioCourseWork.Data;
using RioCourseWork.Models;

namespace RioCourseWork.Areas.MainArea.Workers
{
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        private readonly Repository repo;
        public CreateModel(Repository repo)
        {
            this.repo = repo;
        }
        public Person person { get; set; } = new Person();

        public IActionResult OnGetAsync()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAddAsync(Person person)
        {
            await repo.CreatePerson(person);
            return RedirectToAction("Index", "Home");
        }
    }
}
