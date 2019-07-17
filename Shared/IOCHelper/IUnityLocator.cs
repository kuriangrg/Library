using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.IOCHelper
{
    /// <summary>
    /// The unity locator contract that is shared across the project
    /// </summary>
   public interface IUnityLocator
    {
        T GetLocator<T>();
    }
}
