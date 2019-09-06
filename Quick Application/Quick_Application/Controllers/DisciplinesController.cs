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
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using DAL.Core.Interfaces;

namespace Quick_Application.Controllers
{
    [Route("api/[controller]")]
    public class DisciplinesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IAccountManager _accountManager;

        public DisciplinesController(IMapper mapper, IUnitOfWork unitOfWork, ILogger<DisciplinesController> logger, IAccountManager accountManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _accountManager = accountManager;
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
        public IActionResult Get(int id)
        {
            var discipline = _unitOfWork.Disciplines.Find(_ => _.Id == id);
            return Ok(_mapper.Map<DisciplineViewModel>(discipline));
        }



        // POST api/values
        [HttpPost("roles")]
        [Authorize(Authorization.Policies.ManageAllRolesPolicy)]
        [ProducesResponseType(201, Type = typeof(DisciplineViewModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateDiscipline([FromBody]DisciplineViewModel value)
        {
            if (ModelState.IsValid)
            {
                if (value == null)
                    return BadRequest($"{nameof(value)} cannot be null");


                Discipline model = _mapper.Map<Discipline>(value);

                var result = await _accountManager.CreateDisciplineAsync(model);
                if (result.Succeeded)
                {
                    DisciplineViewModel vm = await GetDisciplineViewModelHelper(appRole.Name);
                    return CreatedAtAction(GetRoleByIdActionName, new { id = roleVM.Id }, roleVM);
                }

                AddError(result.Errors);
            }

            return BadRequest(ModelState);
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            var discipline = _unitOfWork.Disciplines.Find(_ => _.Id == id);

        }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private async Task<DisciplineViewModel> GetDisciplineViewModelHelper(string name)
        {
            var model = await _accountManager.GetDisciplineLoadRelatedAsync(name);
            if (model != null)
                return _mapper.Map<DisciplineViewModel>(model);


            return null;
        }
    }
}
