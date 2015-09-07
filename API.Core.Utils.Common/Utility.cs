using System;

namespace API.Core.Utils.Common
{
    public class Utility
    {
        public T GetInstance<T>(string type)
        {
            return (T) Activator.CreateInstance(Type.GetType(type));
        }

    }
}
