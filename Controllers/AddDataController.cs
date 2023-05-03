using datafromexceltryingon3tables.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace datafromexceltryingon3tables.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AddDataController : ControllerBase
    {
        logic _l;

        public AddDataController   (logic l)
        {
            _l = l;
        }
        [HttpPost]
        [Route("AddData")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<string> addingData()
        {
           return _l.SeedData();
            
        }
    }
}
