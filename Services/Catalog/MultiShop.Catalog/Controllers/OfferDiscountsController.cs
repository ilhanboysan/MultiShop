using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscount;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class OfferDiscountsController : ControllerBase
	{
		private readonly IOfferDiscountService _OfferDiscountService;

		public OfferDiscountsController(IOfferDiscountService offerDiscountService)
		{
			_OfferDiscountService = offerDiscountService;
		}
		[HttpGet]
		public async Task<IActionResult> OfferDiscountList()
		{
			var values = await _OfferDiscountService.GetAllOfferDiscountAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetOfferDiscountById(string id)
		{
			var values = await _OfferDiscountService.GetByIdOfferDiscountAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
		{
			await _OfferDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
			return Ok("Özel Teklif Eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteOfferDiscount(string id)
		{
			await _OfferDiscountService.DeleteOfferDiscountAsync(id);
			return Ok("Özel Teklif Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			await _OfferDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
			return Ok("Özel Teklif Güncellendi");
		}
	}
}
