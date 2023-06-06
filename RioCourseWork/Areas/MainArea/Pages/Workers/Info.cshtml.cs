using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RioCourseWork.Data;
using RioCourseWork.Models;

namespace RioCourseWork.Areas.MainArea.Pages.Workers
{
    public class InfoModel : PageModel
    {
        private readonly Repository repo;
        public Person Person { get; set; }

        public InfoModel(Repository repo)
        {
            this.repo = repo;
        }

        public async Task OnGetAsync(int id)
        {
            Person = await repo.GetPerson(id);
        }
        public async Task<IActionResult> OnPostSave(Person Person, int id)
        {
            Person.Id = id;
            await repo.UpdatePerson(Person);
            return RedirectToPage("List");
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await repo.DeletePerson(id);
            return RedirectToPage("List");
        }
        public async Task OnPostUploadPhotoAsync(IFormFile img, int id)
        {

            await OnGetAsync(id);
        }
    }
}
