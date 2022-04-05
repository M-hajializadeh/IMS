using IMS.CoreBusiness.Model;

namespace IMS.UseCases.DataStoreUseCase.ProductUseCase
{
    public interface IAddProductUseCase
    {
        void Execute(Product product);
    }
}