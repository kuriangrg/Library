using Model.PersonModel;

namespace DAL.PersonManager
{
    public interface IPersonsDataManager
    {
        PersonVM GetPersonsList(int pageIndex, int pageSize);
        Person GetPersonDetails(string personID);
    }
}
