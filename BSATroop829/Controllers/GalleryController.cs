using BSATroop829.Data;
using BSATroop829.Models;
using Microsoft.AspNetCore.Mvc;

namespace BSATroop829.Controllers
{
    public class GalleryController : Controller
    {
        ApplicationDbContext db;
        public GalleryController(ApplicationDbContext db)
        {
            this.db = db;

        }
        public IActionResult Index()
        {
            GalleryViewModel viewModel = new GalleryViewModel();
            viewModel.PhotosList = db.PhotoGallery.ToList();
            viewModel.Photos = new PhotoGalleryVeiwModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddPhotos(GalleryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var Files = model.Photos.PhotoFile;

            if (Files.Count > 0)
            {
                foreach (var item in Files)
                {
                    PhotoGalleryVeiwModel photography = new PhotoGalleryVeiwModel();
                    var guid = Guid.NewGuid().ToString();
                    var filePath = "wwwroot/Resources/" + guid + item.FileName;
                    var fileName = guid + item.FileName;
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        item.CopyTo(stream);
                        photography.Name = fileName;
                        photography.Path = filePath;
                        photography.Title = item.FileName;
                        photography.NoOfViews = 1;
                        db.PhotoGallery.Add(photography);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }
        
        public IActionResult DeletePhoto(int id)
        {
            var photo = db.PhotoGallery.Find(id);
            if(photo != null)
           {
                
                System.IO.File.Delete(photo.Path);
                db.PhotoGallery.Remove(photo);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
        
    }
}
