using System;

namespace Master.DesignPatterns.Creational
{
    public class Singleton
    {
        private Singleton(DateTime creationTime) 
        {
            CreationTime = creationTime;
        }

        private static Singleton _instance = null;
        private static readonly object _object = new object();

        public static Singleton GetInstance
        {
            get
            {
                if(_instance == null)
                {
                   lock(_object)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton(DateTime.Now);
                        }
                    }
                }
                return _instance;
            }
        }

        #region Data Members
        public DateTime CreationTime { get; private set; }
        #endregion
    }
}
