using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargocustomerService;

        public CargoCustomersController(ICargoCustomerService cargocustomerService)
        {
            _cargocustomerService = cargocustomerService;
        }

        [HttpGet]
        public IActionResult CargocustomerList()
        {
            var values = _cargocustomerService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargocustomer(CreateCargoCustomerDto createCargocustomerDto)
        {
            CargoCustomer cargocustomer = new CargoCustomer()
            {
                Address = createCargocustomerDto.Address,
                City = createCargocustomerDto.City,
                District = createCargocustomerDto.District,
                Email = createCargocustomerDto.Email,
                Name = createCargocustomerDto.Name,
                Phone = createCargocustomerDto.Phone,
                Surname = createCargocustomerDto.Surname

            };
            _cargocustomerService.TInsert(cargocustomer);
            return Ok("Kargo Müşteri Başarıyla Oluşturuldu");
        }
        [HttpDelete]
        public IActionResult RemoveCargocustomer(int id)
        {
            _cargocustomerService.TDelete(id);
            return Ok("Kargo Müşteri Başarıyla Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargocustomerById(int id)
        {
            var values = _cargocustomerService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargocustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargocustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                Phone = updateCargoCustomerDto.Phone,
                Surname = updateCargoCustomerDto.Surname
            };
            _cargocustomerService.TUpdate(cargocustomer);
            return Ok("Kargo Müşteri Başarıyla Güncellendi");
        }
    }
}
