using Model.PersonModel;
using DAL.PersonManager;
using Model.PersonModels;
using Shared.IOCHelper;
using Shared.Logger;

namespace BL.PersonService
{
    /// <summary>
    /// Methods to manipulate or read the person data
    /// </summary>
    public class PersonDetailsService : IPersonDetailsService
    {
        private readonly IPersonsDataManager PersonsManager;
        private readonly ILogger Logger;

        /// <summary>
        /// Inject personsdatamanager for data services
        /// </summary>
        /// <param name="personsManager"></param>
        public PersonDetailsService(IUnityLocator unityLocator)
        {
            PersonsManager = unityLocator.GetLocator<IPersonsDataManager>();
            Logger = unityLocator.GetLocator<ILogger>();
        }

        /// <summary>
        /// To get the list of persons by specifying the boundary conditions
        /// </summary>
        /// <param name="personFilterRequest">Specifies the page index and pagesize</param>
        /// <returns>List of persons from boundary conditions and total number of persons </returns>
        public PersonVM GetPersonsList(PersonListRequestFilter personFilterRequest)
        {
            Logger.Debug("GetPersonsList, PersonListRequestFilter:" + personFilterRequest);
            return  (personFilterRequest!=null)? 
                PersonsManager.GetPersonsList(personFilterRequest.PageIndex,personFilterRequest.PageSize):null;
        }
    }
}
