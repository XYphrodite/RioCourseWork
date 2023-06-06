using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RioCourseWork.Data;
using RioCourseWork.Models;

namespace RioCourseWork.Areas.MainArea.Pages.Journal
{
    public class ListModel : PageModel
    {
        private readonly Repository repo;

        public List<Record> records { get; set; } = new List<Record>();

        public ListModel(Repository repo)
        {
            this.repo = repo;
        }

        public async void OnGet()
        {
            records = await repo.GetRecords();
        }
    }
}
