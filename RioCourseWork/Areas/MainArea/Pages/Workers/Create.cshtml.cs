using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RioCourseWork.Data;
using RioCourseWork.Models;

namespace RioCourseWork.Areas.MainArea.Workers
{
    public class CreateModel : PageModel
    {
        private readonly Repository repo;

        public CreateModel(Repository repo)
        {
            this.repo = repo;
        }

        public Person person { get; set; } = new Person();

        public async Task OnGetAsync(Person person)
        {
            await repo.CreatePerson(person)
        }
    }
}
