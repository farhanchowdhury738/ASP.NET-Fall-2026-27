using Microsoft.AspNetCore.Mvc;
using LabDb.EF;

namespace LabDb.Controllers
{
    public class RiderController : Controller
    {
        private readonly AppDbContext _context;
        public RiderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.rider
                .Where(r => r.totalDelivery > 150
                         && r.totalDistance > 550
                         && r.rating > 4.2)
                .Select(r => new
                {
                    r.name,
                    r.id,
                    AvgDelivery = r.totalDelivery / r.totalWorking,
                    AvgDistance = r.totalDistance / r.totalWorking,
                    MinRating = r.rating
                })
                .ToList();

            return View(data);
        }
    }
}
