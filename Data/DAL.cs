using Barberia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Barberia.Data
{
    public interface IDAL
    {
        List<Event> GetEvents();
        List<Event> GetMyEvents(string userid);
        Event? GetEvent(int id);
        void CreateEvent(Event myEvent);  // Modificado para aceptar Event
        void UpdateEvent(Event myEvent);  // Modificado para aceptar Event
        void DeleteEvent(int id);
    }

    public class DAL : IDAL
    {
        private readonly ApplicationDbContext _db;

        public DAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Event> GetEvents()
        {
            return _db.Events.ToList();
        }

        public List<Event> GetMyEvents(string userid)
        {
            return _db.Events.Where(x => x.UserId == userid).ToList();
        }

        public Event? GetEvent(int id)
        {
            return _db.Events.FirstOrDefault(x => x.Id == id);
        }

        public void CreateEvent(Event myEvent)  // Modificado para aceptar Event
        {
            _db.Events.Add(myEvent);
            _db.SaveChanges();
        }

        public void UpdateEvent(Event myEvent)  // Modificado para aceptar Event
        {
            _db.Entry(myEvent).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            var myEvent = _db.Events.Find(id);
            if (myEvent != null)
            {
                _db.Events.Remove(myEvent);
                _db.SaveChanges();
            }
        }
    }
}