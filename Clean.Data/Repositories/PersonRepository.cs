using Clean.Domain.Entities;
using Clean.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly CleanDbContext _context;
    public PersonRepository(CleanDbContext context)
    {
        _context = context;
    }

    public async Task Add(PersonEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var person = await GetById(id);
        if (person != null)
        {
            person.IsDeleted = true;
            _context.Person.Update(person);
            await _context.SaveChangesAsync();
        }
        else { throw new Exception(); }
    }

    public IEnumerable<PersonEntity> GetAll() => _context.Person.Where(p => !p.IsDeleted);

    public async Task<PersonEntity> GetById(int id) => await _context.Person.FindAsync(id);

    public async Task Update(PersonEntity entity)
    {
        var person = await GetById(entity.Id);
        person.FirstName = entity.FirstName;
        person.LastName = entity.LastName;
        
        _context.Person.Update(person);
        await _context.SaveChangesAsync();
    }
}
