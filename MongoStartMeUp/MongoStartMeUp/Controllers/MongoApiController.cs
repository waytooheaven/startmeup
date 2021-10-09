using Microsoft.AspNetCore.Mvc;
using MongoStartMeUp.Models;
using MongoStartMeUp.Service;
using MongoStartMeUp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoStartMeUp.Controllers
{
    [Route("api/[controller]")]
    public class MongoApiController : Controller
    {
        StartmeupService _service;
        public MongoApiController(StartmeupService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("GetAllByPaging")]
        public IActionResult GetAllByPaging(int page, int size)
        {
            return Ok(_service.Get(page, size));
        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody]  MyPoco poco)
        {
            MyObject obj = new MyObject();
            obj.Name = poco.Name;
            obj.Value = poco.Value;
            _service.Insert(obj);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromBody]  MyPoco poco)
        {
            if (string.IsNullOrEmpty(poco.MongoId))
            {
                return BadRequest();
            }
            MyObject obj = new MyObject();
            obj.MongoId = poco.MongoId;
            _service.Delete(obj);
            return Ok();
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody]  MyPoco poco)
        {
            if (string.IsNullOrEmpty(poco.MongoId))
            {
                return BadRequest();
            }
            MyObject obj = new MyObject();
            obj.MongoId = poco.MongoId;
            obj.Value = poco.Value;
            _service.Update(obj);
            
            return Ok();
        }
        [HttpPost]
        [Route("RandomGeneration")]
        public IActionResult RandomGeneration()
        {
            _service.RandomGenerate();
            return Ok();
        }
    }
}
