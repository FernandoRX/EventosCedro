using Server.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Dal.DataAccessObject
{
    public class EventoDao
    {
		DataBase _instance = DataBase.Instance;

		public void Create(Evento evento)
		{
			_instance.Eventos.Add(evento);
			_instance.SaveChanges();
		}

		public void Delete(int id)
		{
			var evento = GetById(id);
			_instance.Eventos.Remove(evento);
			_instance.SaveChanges();
		}

		public List<Evento> GetEventos()
		{
			_instance.Participantes.ToList();
			return _instance.Eventos.ToList();
		}

		public Evento GetById(int id)
		{
			_instance.Participantes.ToList();
			return _instance.Eventos.Find(id);
		}

		public void Update(Evento evento)
		{
			_instance.Eventos.Update(evento);
			_instance.SaveChanges();
		}
	}
}
