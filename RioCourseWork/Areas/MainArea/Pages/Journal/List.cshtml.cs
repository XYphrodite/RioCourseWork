using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RioCourseWork.Data;
using RioCourseWork.Models;

namespace RioCourseWork.Areas.MainArea.Pages.Journal
{
    public class ListModel : PageModel
    {
        private readonly Repository repo;

        public List<JournalItem> journalItems { get; set; } = new();

        public ListModel(Repository repo)
        {
            this.repo = repo;
        }

        public async Task OnGet()
        {
            journalItems = await repo.GetJournalItems();
        }

        public async Task OnPostDeleteAsync(int id)
        {
            await repo.DeleteJournalItem(id);
            await OnGet();
        }
    }
}
