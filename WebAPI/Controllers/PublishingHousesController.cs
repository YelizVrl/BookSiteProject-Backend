using Business.Abstract;
using Entities.Concrete;
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
    public class PublishingHousesController : ControllerBase
    {

        IPublishingHouseService _publishingHouseService;

        public PublishingHousesController(IPublishingHouseService publishingHouseService)
        {
            _publishingHouseService = publishingHouseService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _publishingHouseService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(PublishingHouse publishingHouse)
        {
            var result = _publishingHouseService.Add(publishingHouse);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("update")]
        public IActionResult Update(PublishingHouse publishingHouse)
        {
            var result = _publishingHouseService.Update(publishingHouse);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(PublishingHouse publishingHouse)
        {
            var result = _publishingHouseService.Delete(publishingHouse);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
