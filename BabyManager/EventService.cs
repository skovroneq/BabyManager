using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyManager
{
    public class EventService
    {
        public List<Event> Items { get; set; }
        public EventService()
        {
            Items = new List<Event>();
        }

        public void AddNewEventView(MenuActionService actionService)
        {

        }
    }
}
