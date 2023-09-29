using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clean.Application.DTOs;

namespace Clean.Application.Interfaces;

public interface IPersonService : IGenericService<PersonDto>
{
}
