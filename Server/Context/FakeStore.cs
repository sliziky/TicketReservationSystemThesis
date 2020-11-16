using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketReservationSystem.Server.Context
{
    public class FakeDataStore
    {
        private static List<string> _values;
        public FakeDataStore()
        {
            _values = new List<string>
        {
            "a",
            "b",
            "c"
        };
        }
        public void AddValue(string value)
        {
            _values.Add(value);
        }
        public IEnumerable<string> GetAllValues()
        {
            return _values;
        }
    }
}
