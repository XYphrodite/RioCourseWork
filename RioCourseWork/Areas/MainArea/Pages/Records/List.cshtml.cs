using Microsoft.AspNetCore.Mvc.RazorPages;
using RioCourseWork.Data;
using RioCourseWork.Models;

namespace RioCourseWork.Areas.MainArea.Pages.Records
{
    public class ListModel : PageModel
    {
        private readonly Repository repo;

        public ListModel(Repository repo)
        {
            this.repo = repo;
        }

        public List<Record> records { get; set; } = new();
        public async Task OnGet()
        {
            records = await repo.GetRecords();
        }
    }
}
