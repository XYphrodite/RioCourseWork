using Microsoft.AspNetCore.Mvc.RazorPages;
using RioCourseWork.Data;
using RioCourseWork.Models;

namespace RioCourseWork.Areas.MainArea.Workers
{
    public class ListModel : PageModel
    {
        private readonly Repository repo;

        public ListModel(Repository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Person> Persons { get; set; } = new List<Person>();
        public async Task OnGet()
        {
            Persons = await repo.GetPersons();
        }
    }
}
