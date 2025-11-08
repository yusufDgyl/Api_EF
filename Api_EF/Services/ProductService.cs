using AutoMapper;
using MamiYummy.Data;
using MamiYummy.Dto.Product;
using MamiYummy.Interfaces;
using MamiYummy.Models;
using Microsoft.EntityFrameworkCore;

namespace MamiYummy.Services
{
    public class ProductService : IGeneralService<AddProductDto,UpdateProductDto,GetProductDto>
    {
        private readonly IReporsitory<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IReporsitory<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Add(AddProductDto addProductDto)
        {
            var entity =_mapper.Map<Product>(addProductDto);
            _repository.Add(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<GetProductDto> GetAll()
        {
           var entity = _mapper.Map<List<GetProductDto>>(_repository.GetAll());
            return entity;

        }

        public GetProductDto GetById(int id)
        {
           var entity = _mapper.Map<GetProductDto>(_repository.GetById(id));
           return entity;
        }

        public void Update(int id, UpdateProductDto updateProductDto)
        {
            var guncellenicek = _repository.GetById(id);
            _mapper.Map(updateProductDto, guncellenicek);
            _repository.Update(id,guncellenicek);
        }
    }
}
