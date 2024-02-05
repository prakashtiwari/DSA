using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShowLLD.Repository
{
    public class MovieRepository : IRepository
    {
        public MovieRepository()
        { 
        }
        public void Add<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get<T>()
        {
            throw new NotImplementedException();
        }
    }
}
