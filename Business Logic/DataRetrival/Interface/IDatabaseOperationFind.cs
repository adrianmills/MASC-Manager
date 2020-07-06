using Business_Logic.View_Model.Interface;

namespace Business_Logic.DataRetrival.Interface
{
    public interface IDatabaseOperationDetail<T> where T: IViewModelBase
    {

        T Detail(long id);
    }
}
