using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RioCourseWork.Data;
using RioCourseWork.Models;
using System.Drawing;
using RioCourseWork.Services;

namespace RioCourseWork.Areas.MainArea.Pages.Workers
{
    public class InfoModel : PageModel
    {
        private readonly Repository repo;
        private readonly FaceControlling faceRecognizer;

        public Person Person { get; set; }
        public bool HasPhoto { get; set; } = false;

        public InfoModel(Repository repo, FaceControlling faceRecognizer)
        {
            this.repo = repo;
            this.faceRecognizer = faceRecognizer;
        }

        public async Task OnGetAsync(int id)
        {
            Person = await repo.GetPerson(id);
            HasPhoto = faceRecognizer.Check(id);
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
            if (img is null)
                return;
            await faceRecognizer.Add(img, id);
            await OnGetAsync(id);
        }
    }
}
