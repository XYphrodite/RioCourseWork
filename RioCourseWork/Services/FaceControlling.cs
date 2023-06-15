using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;
using System.Drawing.Imaging;
using VisioForge.MediaFramework.Helpers;

namespace RioCourseWork.Services
{
    public class FaceControlling
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FaceControlling(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task Add(IFormFile img, Guid id)
        {
            var path = Path.Combine(webHostEnvironment.WebRootPath, "Faces", id.ToString()+".jpg");
            using (var memoryStream = new FileStream(path, FileMode.Create))
                await img.CopyToAsync(memoryStream);
        }

        public bool Check(Guid id)
        {
            FileInfo f = new FileInfo(Path.Combine(webHostEnvironment.WebRootPath, "Faces", id.ToString() + ".jpg"));
            return f.Exists;
        }


    }
}
