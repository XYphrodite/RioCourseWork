using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RioCourseWork.Data;
using RioCourseWork.Models;

namespace RioCourseWork.Areas.MainArea.Pages.Camera
{
    public class CamModel : PageModel
    {
        public IEnumerable<Person> people { get; set; }
        private readonly Repository repo;

        public CamModel(Repository repo)
        {
            this.repo = repo;
        }

        public async Task OnGet()
        {
            people = await repo.GetPersons();
        }

        public async Task OnPostOpen(int id)
        {
            await repo.CamOpen(id);
        }
    }
}
