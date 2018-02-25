using Server.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Dal.DataAccessObject
{
    public class ParticipanteDao
    {
		DataBase _instance = DataBase.Instance;

		public void Create(Participante participante)
		{
			_instance.Participantes.Add(participante);
			_instance.SaveChanges();
		}

		public void Delete(int id)
		{
			var participante = GetById(id);
			_instance.Participantes.Remove(participante);
			_instance.SaveChanges();
		}

		public List<Participante> GetParticipantes()
		{
			return _instance.Participantes.ToList();
		}

		public Participante GetById(int id)
		{
			return _instance.Participantes.Find(id);
		}

		public void Update(Participante participante)
		{
			_instance.Participantes.Update(participante);
			_instance.SaveChanges();
		}
	}
}
