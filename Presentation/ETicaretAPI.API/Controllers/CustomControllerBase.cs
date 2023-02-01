using GOAL.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GOAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
        public IActionResult CreateActionResult<T>(CustomResponse<T> response) 
        {
            return new ObjectResult(response.StatusCode == 204 ? null : response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
