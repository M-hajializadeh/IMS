using IMS.CoreBusiness.Model;

namespace IMS.UseCases.DataStoreUseCase.ProductUseCase
{
    public interface IProductUseCase
    {
        IEnumerable<Product> Execute();
    }
}