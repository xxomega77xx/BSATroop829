using BSATroop829.Data;
using BSATroop829.Models;
using BSATroop829.Services;
using EllipticCurve.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BSATroop829.Controllers
{
    [Authorize]
    public class FileManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly LogService _logService;

        public FileManagerController(ApplicationDbContext context, LogService logService)
        {
            _context = context;
            _logService = logService;
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
                    var fileName = guid + "_" + item.FileName;
                    var filePath = "wwwroot/Resources/Files/" + fileName;
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        item.CopyTo(stream);
                        currentFile.Name = fileName;
                        currentFile.Path = filePath;
                        _context.FileManager.Add(currentFile);
                        _context.SaveChanges();
                        _logService.Log(User.Identity.Name, "Added file " + currentFile.Name);
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
                _logService.Log(User.Identity.Name, "removed file " + file.Name);
            }
            return RedirectToAction("index");
        }

        public IActionResult DownloadFile(int id)
        {
            var file = _context.FileManager.Find(id);
            if (file != null)
            {
                byte[] bytes = System.IO.File.ReadAllBytes(file.Path);
                return File(bytes, "application/octet-stream", file.Name.Split('_')[1]);
            }
            _logService.Log(User.Identity.Name, "downloaded file " + file.Name);
            return RedirectToAction("index");
        }

        private bool FileManagerViewModelExists(int id)
        {
          return (_context.FileManager?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
