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
using AutoMapper;

namespace Clean.Application.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PersonDto> GetByIdAsync(int id)
    {
        var person = await Task.Run(() => _repository.GetById(id));
        return _mapper.Map<PersonDto>(person);
    }
    public async Task<IEnumerable<PersonDto>> GetAllAsync()
    {
        var persons = await Task.Run(_repository.GetAll);
        return persons.Select(_mapper.Map<PersonDto>);
    }
    public async Task AddAsync(PersonDto dto) => await _repository.Add(_mapper.Map<PersonEntity>(dto));
    public async Task DeleteAsync(int id) => await _repository.Delete(id);
    public async Task UpdateAsync(PersonDto dto) => await _repository.Update(_mapper.Map<PersonEntity>(dto));
}

