namespace IMS.UseCases.DataStoreUseCase.ProductsInCategory
{
    public interface ICheckOutProductUseCase
    {
        void Execute(string workerName,int productId, int qtyToCkeckOut);
    }
}