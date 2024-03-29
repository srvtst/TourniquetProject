﻿using Tourniquet.Application.Repositories;
using Tourniquet.Domain.Entities;
using Tourniquet.Persistence.Context;

namespace Tourniquet.Persistence.Repositories
{
    public class PersonWriteRepository : WriteGenericRepository<Person, TurnstileDbContext>, IPersonWriteRepository
    {
        public PersonWriteRepository(TurnstileDbContext context) : base(context)
        {
        }
    }
}