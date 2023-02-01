using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Interfaces
{
    public interface IDBOperationRepository
    {
        public List<T> Query<T>(string query, object parameters);
        public string Execute(string query, object parameters);
    }
}
