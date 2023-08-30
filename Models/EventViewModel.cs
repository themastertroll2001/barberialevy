using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
namespace Barberia.Models
{
    public class EventViewModel
    {
        public Event? Event { get; set; }
        public string? UserId { get; set; }

        public EventViewModel() { }

        public EventViewModel(Event myEvent, string userId)
        {
            Event = myEvent;
            UserId = userId;
        }
    }
}
