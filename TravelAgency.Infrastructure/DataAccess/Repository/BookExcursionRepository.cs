using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Domain.Relations;
using TravelAgency.Infrastructure.Common.Utilities;
using TravelAgency.Infrastructure.DataAccess.IRepository;

namespace TravelAgency.Infrastructure.DataAccess.Repository
{
    public class BookExcursionRepository : GenericRepository<BookExcursion>, IBookExcursionRepository
    {
        public BookExcursionRepository(TravelAgencyContext context) : base(context) {}
    }
}