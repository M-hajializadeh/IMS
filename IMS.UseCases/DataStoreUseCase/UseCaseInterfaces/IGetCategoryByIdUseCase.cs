
namespace IMS.UseCases.DataStoreUseCase.Category
{
    public interface IGetCategoryByIdUseCase
    {
        CoreBusiness.Model.Category Execute(int id);
    }
}