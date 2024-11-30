using SameerIbseleh_Carseer.Services.HomeServices;
namespace SameerIbseleh_Carseer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }
        #region Views
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        #region EndPonits
        [HttpPost]
        public async Task<IActionResult> GetAllMakes()
        {
            try
            {   
                var data = await _homeService.GetAllMakes();
                return Ok(new { Result = data, Count = data.Count, ErrorMessage = "Success" });
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        public async Task<IActionResult> GetVehicleTypes(int id)
        {
            try
            {
                var data = await _homeService.GetVehicleTypes(id);
                return Ok(new { Result = data, Count = data.Count, ErrorMessage = "Success" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> GetVehicleModels(int makeId, int modelYear)
        {
            try
            {
                var data = await _homeService.GetVehicleModels(makeId, modelYear);
                return Ok(new { Result = data, Count = data.Count, ErrorMessage = "Success" });
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
