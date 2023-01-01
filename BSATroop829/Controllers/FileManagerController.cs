using BSATroop829.Data;
using BSATroop829.Models;
using EllipticCurve.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BSATroop829.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FileManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FileManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FileManager
        public IActionResult Index()
        {
            FilesViewModel viewModel = new FilesViewModel();
            viewModel.FileList = _context.FileManager.ToList();
            viewModel.Files = new FileManagerViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddFiles(FilesViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var Files = model.Files.File;

            if (Files.Count > 0)
            {
                foreach (var item in Files)
                {
                    FileManagerViewModel currentFile = new FileManagerViewModel();
                    var guid = Guid.NewGuid().ToString();
                    var filePath = "wwwroot/Resources/Files" + guid + item.FileName;
                    var fileName = guid + item.FileName;
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        item.CopyTo(stream);
                        currentFile.Name = fileName;
                        currentFile.Path = filePath;
                        _context.FileManager.Add(currentFile);
                        _context.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }
        
        public IActionResult DeleteFile(int id)
        {
            var file = _context.FileManager.Find(id);
            if(file != null)
           {
                
                System.IO.File.Delete(file.Path);
                _context.FileManager.Remove(file);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }

        public IActionResult DownloadFile(int id)
        {
            var file = _context.FileManager.Find(id);
            if (file != null)
            {
                byte[] bytes = System.IO.File.ReadAllBytes(file.Path);
                return File(bytes, "application/octet-stream", file.Path);
            }
            return RedirectToAction("index");
        }

        private bool FileManagerViewModelExists(int id)
        {
          return (_context.FileManager?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
