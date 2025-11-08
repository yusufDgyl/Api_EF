using MamiYummy.Dto.Product;
using MamiYummy.Interfaces;
using MamiYummy.Models;
using Microsoft.AspNetCore.Mvc;

namespace MamiYummy.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly IGeneralService<AddProductDto,UpdateProductDto,GetProductDto> _productService;

        public ProductsController(IGeneralService<AddProductDto, UpdateProductDto, GetProductDto> productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Ekle(AddProductDto addProductDto)
        {
            _productService.Add(addProductDto);
            return Ok("Ekleme başarılı!");

        }
        [HttpDelete]
        public IActionResult Sil(int id)
        {
            _productService.Delete(id);
            return Ok("Silme Başarılı!");

        }
        [HttpPut]
        public IActionResult Guncelle(int id, UpdateProductDto updateProductDto)
        {
            _productService.Update(id, updateProductDto);
            return Ok("Güncelleme başarılı!");

        }
        [HttpGet("Getbyid")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            return Ok(product);

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _productService.GetAll();
            return Ok(productList);
        }
    }
}
