using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.API.DTOs;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _cusService;
        private IMapper _mapper;

        public CustomerController(ICustomerService cusService, IMapper mapper)
        {
            _cusService = cusService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cus = await _cusService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(cus));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cus = await _cusService.GetByIdAsync(id);
            return Ok(_mapper.Map<CustomerDto>(cus));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto cusDto)
        {
            var newCus = await _cusService.AddAsync(_mapper.Map<Customer>(cusDto));
            return Created(String.Empty, cusDto);
            //_mapper.Map<CategoryDto>(newCat)
        }

        [HttpPut]
        public IActionResult Update(CustomerDto cusDto)
        {
            var cus = _cusService.Update(_mapper.Map<Customer>(cusDto));
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Remove(Guid id)
        {
            var cus = _cusService.GetByIdAsync(id).Result;
            _cusService.Remove(cus);
            return NoContent();
        }

        [HttpDelete("{name:alpha}")]
        public IActionResult RemoveByName(string name)
        {
            var cus = _cusService.FirstOrDefaultAsync(s => s.Name == name).Result;
            _cusService.Remove(cus);
            return NoContent();
        }
    }
}
