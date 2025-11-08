using AutoMapper;
using MamiYummy.Dto.Product;
using MamiYummy.Dto.User;
using MamiYummy.Interfaces;
using MamiYummy.Models;

namespace MamiYummy.Services
{
    public class UserService :IGeneralService<AddUserDto,UpdateUserDto,GetUserDto>
    {
        private readonly IReporsitory<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IReporsitory<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Add(AddUserDto addUserDto)
        {
            var entity = _mapper.Map<User>(addUserDto);
            _repository.Add(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<GetUserDto> GetAll()
        {
            var entity = _mapper.Map<List<GetUserDto>>(_repository.GetAll());
            return entity;

        }

        public GetUserDto GetById(int id)
        {
            var entity = _mapper.Map<GetUserDto>(_repository.GetById(id));
            return entity;
        }

        public void Update(int id, UpdateUserDto updateUserDto)
        {
            var guncellenicek = _repository.GetById(id);
            _mapper.Map(updateUserDto, guncellenicek);
            _repository.Update(id, guncellenicek);
        }
    }
}

