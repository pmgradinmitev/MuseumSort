using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuseumSort.Data;
using MuseumSort.Data.Entities;
using MuseumSort.ViewModels;

namespace MuseumSearch.Controllers
{
    public class PaintingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PaintingController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Index(PaintingsTableViewModel model)
        {
            IQueryable<Painting> query = _context.Set<Painting>();
            int recordsTotal = query.Count();
            query = OrderBy(model, query);
            model.RecordsTotal = recordsTotal;
            model.Data = query.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            PaintingViewModel model = new PaintingViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PaintingViewModel viewModel)
        {
            Painting entity = new Painting();
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.MapTo(entity);
                    _context.Paintings.Add(entity);
                    _context.SaveChanges();
                    TempData["success"] = $"Картина \"{entity.Name}\" е добавена успешно!";
                }
                catch
                {
                    TempData["error"] = "Картината не може да бъде добавена!";
                }
            }
            return View(viewModel);
        }

        public IActionResult Update(int Id)
        {
            Painting? entity = _context.Paintings.Find(Id);
            if(entity == null)
            {
                TempData["error"] = "картината не може да бъде намерена!";
                return RedirectToAction("Index");
            }
            PaintingViewModel viewModel = new PaintingViewModel();
            viewModel.MapFrom(entity);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(PaintingViewModel viewModel)
        {
            Painting entity = _context.Paintings.Find(viewModel.Id);
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.MapTo(entity);
                    _context.Paintings.Update(entity);
                    _context.SaveChanges();
                    TempData["success"] = $"Картина \"{entity.Name}\" е записана успешно!";
                }
                catch
                {
                    TempData["error"] = "Промените не бяха записани!";
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Painting? entity = _context.Paintings.Find(Id);
            if (entity == null)
            {
                TempData["error"] = "Такава картина не съществува!";
                return RedirectToAction("Index");
            }
            try
            {
                _context.Paintings.Remove(entity);
                _context.SaveChanges();
                TempData["success"] = $"Картина \"{entity.Name}\" е изтрита успешно!";
            }
            catch
            {
                TempData["error"] = $"Възникна грешка при изтриването!";
            }
            return RedirectToAction("Index");
        }
        private IQueryable<Painting> OrderBy(PaintingsTableViewModel searchModel, IQueryable<Painting> query)
        {
            switch (searchModel.SortOrder)
            {
                case "-name":
                    return query.OrderByDescending(s => s.Name);
                case "name":
                    return query.OrderBy(s => s.Name);
                case "author":
                    return query.OrderBy(s => s.Author);
                case "-author":
                    return query.OrderByDescending(s => s.Author);
                default:
                    return query;
            }
        }
    }
}
