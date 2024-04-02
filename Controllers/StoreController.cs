using BulwarkApi.Models;
using BulwarkApi.Services.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BulwarkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly ILogger<StoreController> _logger;

        public StoreController(IStoreService storeService, ILogger<StoreController> logger)
        {
            _storeService = storeService;
            _logger = logger;
        }

        [HttpGet, Route("FetchProducts")]
        public ActionResult<List<Product>> FetchProducts()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
    }
}
