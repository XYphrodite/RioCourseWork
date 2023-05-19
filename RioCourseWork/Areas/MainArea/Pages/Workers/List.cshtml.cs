using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RioCourseWork.Data;
using RioCourseWork.Models;

namespace RioCourseWork.Areas.MainArea.Workers
{
    [IgnoreAntiforgeryToken]
    public class ListModel : PageModel
    {
        private readonly Repository repo;

        public ListModel(Repository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Person> Persons { get; set; } = new List<Person>();
        public string Message { get; private set; }

        public async Task OnGet()
        {
            Persons = await repo.GetPersons();
        }
    }
}
