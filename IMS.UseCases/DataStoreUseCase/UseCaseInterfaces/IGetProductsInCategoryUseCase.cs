using IMS.CoreBusiness.Model;

namespace IMS.UseCases.DataStoreUseCase.ProductsInCategory
{
    public interface IGetProductsInCategoryUseCase
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}