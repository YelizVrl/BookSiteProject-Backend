using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageTypesController : ControllerBase
    {
        IPageTypeService _pageTypeService;

        public PageTypesController(IPageTypeService pageTypeService)
        {
            _pageTypeService = pageTypeService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _pageTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
