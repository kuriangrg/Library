using Shared.IOCHelper;
using Unity;
namespace LibrarySystem.IOCLocator
{
    public class UnityLocator : IUnityLocator
    {
        /// <summary>
        /// To return the particular instantiated class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetLocator<T>()
        {
            return UnityConfig.Container.Resolve<T>();
        }
    }
}