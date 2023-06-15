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

        public Person person { get; set; } = new();
        public async Task OnGetAsync(Guid id)
        {
            person = await repo.GetPerson(id);
        }
    }
}
