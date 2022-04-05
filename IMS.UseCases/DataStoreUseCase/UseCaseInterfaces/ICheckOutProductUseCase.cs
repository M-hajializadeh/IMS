namespace IMS.UseCases.DataStoreUseCase.ProductsInCategory
{
    public interface ICheckOutProductUseCase
    {
        void Execute(int productId, int qtyToCkeckOut);
    }
}