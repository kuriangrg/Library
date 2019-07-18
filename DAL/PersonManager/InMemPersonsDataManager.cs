using Model.PersonModel;
using Shared.Logger;
using Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.PersonManager
{
    /// <summary>
    /// The implemenation of PersonData manager to support In memory
    /// data for persons and its manipulation.
    /// </summary>
    public class InMemPersonsDataManager:IPersonsDataManager
    {
        public static PersonVM PersonData;
        private readonly ILogger Logger;
        public InMemPersonsDataManager(ILogger logger,string personXMLFileName)
        {
            this.Logger = logger;
            InitializePersonData(personXMLFileName);
        }

        /// <summary>
        /// Initialize the static variable Person Data from the person.xml hosted
        /// </summary>
        /// <param name="personXMLFileName"></param>
        private  void InitializePersonData(string personXMLFileName)
        {
            try
            {
                if (PersonData == null)
                {
                    XmlSerializer se = new XmlSerializer(typeof(PersonVM));
                    PersonData = (PersonVM)se.Deserialize(Helper.GetStreamFromURL(personXMLFileName));
                    PersonData.TotalPersons = PersonData.Persons.Count();
                }
            }
            catch(Exception ex)
            {
                Logger.Error("Error while streaming Data. File:"+ personXMLFileName, ex);
            }
            
        }

        /// <summary>
        /// To get the list of persons by specifying the boundary conditions from static memory
        /// </summary>
        /// <param name="pageIndex">Specifies the page index</param>
        /// <param name="pageSize">Specifies the page size to be shown</param>
        /// <returns></returns>
        public PersonVM GetPersonsList(int pageIndex, int pageSize)
        {
            return new PersonVM
            {
                Persons = (List<Person>)PersonData.Persons.Skip(pageIndex).Take(pageSize).ToList<Person>(),
                TotalPersons = PersonData.Persons.Count
            };
        }

        /// <summary>
        /// Get the person details from static memory
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public Person GetPersonDetails(string personID)
        {
            return PersonData.Persons.FirstOrDefault(x => x.PersonID == personID);
        }

        
    }
}
