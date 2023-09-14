using AutoMapper;
using Clean.Application.DTOs;
using Clean.Application.Interfaces;
using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonDto> GetByIdAsync(int id)
        {
            var person = await Task.Run(() => _repository.GetById(id));
            return PersonServiceHelpers.ToDto(person);
        }
        public async Task<IEnumerable<PersonDto>> GetAllAsync()
        {
            var persons = await Task.Run(_repository.GetAll);
            return persons.Select(PersonServiceHelpers.ToDto);
        }
        public async Task AddAsync(PersonDto dto) => await _repository.Add(PersonServiceHelpers.ToEntity(dto));
        public async Task DeleteAsync(int id) => await _repository.Delete(id);
        public async Task UpdateAsync(PersonDto entity) => await _repository.Update(PersonServiceHelpers.ToEntity(entity));
    }
    public static class PersonServiceHelpers
    {
        public static PersonDto ToDto(PersonEntity entity)
        {
            return new PersonDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                IsDeleted = entity.IsDeleted
            };
        }

        public static PersonEntity ToEntity(PersonDto dto) 
        {
            return new PersonEntity
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                IsDeleted = dto.IsDeleted
            };
        }
    }
}

