using System;

namespace API.Core.Utils.Common
{ 
    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">class</typeparam>
        /// <param name="value"></param>
        /// <param name="param">the name of the parameter 'T'</param>
        /// <returns></returns>
        public static T CheckNull<T>(this T instance, string param) where T : class
        {
            if (instance == null)
                throw new ArgumentNullException(param);

            return instance;
        }
    }
}
