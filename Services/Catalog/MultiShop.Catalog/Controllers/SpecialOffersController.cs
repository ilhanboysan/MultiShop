﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _SpecialOfferService;

        public SpecialOffersController(ISpecialOfferService SpecialOfferService)
        {
            _SpecialOfferService = SpecialOfferService;
        }
        [HttpGet]
        public async Task<IActionResult> SpecialOfferList()
        {
            var values = await _SpecialOfferService.GetAllSpecialOfferAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var values = await _SpecialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _SpecialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Özel Teklif Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _SpecialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Özel Teklif Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _SpecialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Özel Teklif Güncellendi");
        }
    }
}
