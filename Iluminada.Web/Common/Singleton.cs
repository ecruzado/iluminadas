using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Iluminada.Web.Common
{
    public abstract class Singleton<TEntity> where TEntity : class, new()
    {
        private static readonly Mutex Mutex = new Mutex();
        private static TEntity _instancia;

        public static TEntity Instancia
        {
            get
            {
                Mutex.WaitOne();
                if (_instancia == null)
                {
                    _instancia = new TEntity();
                }
                Mutex.ReleaseMutex();
                return _instancia;
            }
        }
    }
}