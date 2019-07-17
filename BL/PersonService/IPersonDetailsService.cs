using Model.PersonModel;
using Model.PersonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.PersonService
{
    public interface IPersonDetailsService
    {
        PersonVM GetPersonsList(PersonListRequestFilter personFilterRequest);
    }
}
