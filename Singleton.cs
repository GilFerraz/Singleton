namespace Faxime.Common.Design
{
    #region

    using System;

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T>
        where T : Singleton<T>
    {
        #region Static Fields and Constants

        private static T instance;
        private static readonly object threadLock = new object();

        #endregion

        #region Proprieties

        #region Public Proprieties

        /// <summary>
        ///     The instance of this <see cref="Singleton{T}" />.
        /// </summary>
        /// <remarks>
        ///     If the singleton is not initialized, automatically initializes the singleton
        ///     with its private parameterless constructor.
        /// </remarks>
        public static T Instance { get { return GetInstance(); } }

        #endregion

        #endregion

        #region Methods

        #region Private Static Methods

        private static T GetInstance()
        {
            lock (threadLock)
            {
                return instance ?? (instance = Activator.CreateInstance(typeof(T), true) as T);
            }
        }

        #endregion

        #endregion
    }
}