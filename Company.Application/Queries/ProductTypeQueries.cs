using Company.Application.Queries.Interfaces;
using Company.Domain.Entities;

namespace Company.Application.Queries {
    public class ProductTypeQueries : IProductTypeQueries {
        public Task<IEnumerable<ProductType>> GetAllAsync() {
            throw new NotImplementedException();
        }
    }
}
