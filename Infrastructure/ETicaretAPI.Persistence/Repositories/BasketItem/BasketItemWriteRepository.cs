using GOAL.Application.Repositories;
using GOAL.Domain.Entities;
using GOAL.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOAL.Persistence.Repositories
{
    public class BasketItemWriteRepository : WriteRepository<BasketItem>, IBasketItemWriteRepository
    {
        public BasketItemWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
