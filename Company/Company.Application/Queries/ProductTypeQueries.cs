using Company.Application.Queries.Interfaces;
using Company.Company.Domain.Entities;

namespace Company.Company.Application.Queries {
    public class ProductTypeQueries : IProductTypeQueries {
        public Task<IEnumerable<ProductType>> GetAllAsync() {
            throw new NotImplementedException();
        }
    }
}
