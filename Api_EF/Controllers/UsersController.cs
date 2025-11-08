using MamiYummy.Dto.Product;
using MamiYummy.Dto.User;
using MamiYummy.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MamiYummy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGeneralService<AddUserDto,UpdateUserDto,GetUserDto> _userService;

        public UsersController(IGeneralService<AddUserDto, UpdateUserDto, GetUserDto> userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Ekle(AddUserDto addUserDto)
        {
            _userService.Add(addUserDto);
            return Ok("Ekleme başarılı!");

        }
        [HttpDelete]
        public IActionResult Sil(int id)
        {
            _userService.Delete(id);
            return Ok("Silme Başarılı!");

        }
        [HttpPut]
        public IActionResult Guncelle(int id, UpdateUserDto updateUserDto)
        {
            _userService.Update(id, updateUserDto);
            return Ok("Güncelleme başarılı!");

        }
        [HttpGet("Getbyid")]
        public IActionResult GetById(int id)
        {
            var product = _userService.GetById(id);
            return Ok(product);

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var userList = _userService.GetAll();
            return Ok(userList);
        }
    }
}

