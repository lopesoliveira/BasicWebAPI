using Company.Domain.Entities;

namespace Company.Application.Queries.Interfaces {
    public interface IProductTypeQueries {
        Task<IEnumerable<ProductType>> GetAllAsync();
    }
}
