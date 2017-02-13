namespace Faxime.Common.Design
{
    #region

    using System;

    #endregion

    /// <summary>
    /// A generic abstract class to be used in the Singleton design pattern.
    /// All child classes that inherit from this class must have a private parameterless constructor.
    /// The Singleton's initialization is lazy, which means that it will only be initialized when it is first accessed.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the Singleton.</typeparam>
    public abstract class Singleton<T>
        where T : class, Singleton<T>
    {
        #region Static Fields and Constants

        /// <summary>
        ///     The instance of this <see cref="Singleton{T}" />.
        /// </summary>
        private static T instance;

        private static readonly object threadLock = new object();

        #endregion

        #region Proprieties

        #region Public Proprieties

        /// <summary>
        ///     The instance of this <see cref="Singleton{T}" />.
        /// </summary>
        /// <remarks>
        ///  When the singleton is accessed the first time, it automatically constructs the singleton's instance using its
        ///  private parameterless constructor.
        /// </remarks>
        public static T Instance
        {
            get
            {
                lock (threadLock)
                {
                    return instance ?? (instance = Activator.CreateInstance(typeof(T), true) as T);
                }
            }
        }

        #endregion

        #endregion
    }
}