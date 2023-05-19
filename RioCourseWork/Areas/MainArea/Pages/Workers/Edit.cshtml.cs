using Microsoft.AspNetCore.Mvc.RazorPages;
using RioCourseWork.Data;
using RioCourseWork.Models;

namespace RioCourseWork.Areas.MainArea.Workers
{
    public class EditModel : PageModel
    {
        private readonly Repository repo;

        public EditModel(Repository repo)
        {
            this.repo = repo;
        }

        public Person person { get; set; }
        public async Task OnGetAsync(int id)
        {
            person = await repo.GetPersons(id);
        }
    }
}
