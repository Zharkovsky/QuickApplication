using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Quick_Application.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Quick_Application.Helpers;

namespace Quick_Application.Controllers
{
    [Route("api/[controller]")]
    public class DisciplinesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;


        public DisciplinesController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<DisciplinesController> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }



        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var allDisciplines = _unitOfWork.Disciplines.GetAllDisciplinesData();
            return Ok(_mapper.Map<IEnumerable<DisciplineViewModel>>(allDisciplines));
        }



        [HttpGet("throw")]
        public IEnumerable<DisciplineViewModel> Throw()
        {
            throw new InvalidOperationException("Это тестовая ошибка: " + DateTime.Now);
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value: " + id;
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
