using IMS.CoreBusiness.Model;

namespace IMS.UseCases.DataStoreUseCase.ProductUseCase
{
    public interface IGetProductUseCase
    {
        Product Execute(int productId);
    }
}