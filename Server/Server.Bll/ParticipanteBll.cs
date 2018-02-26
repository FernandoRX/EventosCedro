using Microsoft.AspNetCore.Mvc;
using Server.Dal.DataAccessObject;
using Server.Dal.Models;
using Server.Dal.ModelView;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Bll
{
    public class ParticipanteBll
    {
		public List<Participante> GetParticipantes()
		{
			var participanteDao = new ParticipanteDao();
			return participanteDao.GetParticipantes();
		}

		public Participante GetById(int id)
		{
			var participanteDao = new ParticipanteDao();
			return participanteDao.GetById(id);
		}

		public void Create(ParticipanteModelView participanteModelView)
		{
			var participante = new Participante();
			var participanteDao = new ParticipanteDao();
			var eventoBll = new EventoBll();
			var emailBll = new EmailBll();
			participante = PrepareParticipante(participanteModelView, participante);
			var Verify = eventoBll.VerificaSeTemIngresso(participante.IdEvento);
			if (Verify == true)
			{
				participanteDao.Create(participante);
				emailBll.SendEmailWhenRegisters(participante);
			}
			else
			{
				Console.Write("Acabaram os ingressos");
			}
			
		}

		public void Delete(int id)
		{
			var participanteDao = new ParticipanteDao();
			var participante = participanteDao.GetById(id);
			participanteDao.Delete(id);
			var eventoBll = new EventoBll();
			eventoBll.SaiDoEvento(participante.IdEvento);
		}

		public void Update(int id, ParticipanteModelView participanteModelView)
		{
			var participanteDao = new ParticipanteDao();
			var participante = participanteDao.GetById(id);
			if (participante.IdEvento != participanteModelView.IdEvento)
			{
				var eventoBll = new EventoBll();
				var verify = eventoBll.VerificaSeTemIngresso(participanteModelView.IdEvento);
				if (verify == true)
				{
					eventoBll.SaiDoEvento(participante.IdEvento);
				}
				else
				{
					Console.Write("Os ingressos acabaram");
				}
			}
			participante = PrepareParticipante(participanteModelView, participante);
			participanteDao.Update(participante);
		}

		public Participante PrepareParticipante( ParticipanteModelView participanteModelView, Participante participante)
		{
			participante.Nome = participanteModelView.Nome;
			participante.Email = participanteModelView.Email;
			participante.IdEvento = participanteModelView.IdEvento;
			return participante;
		}

		public bool EventoExist(int id)
		{
			var eventoDao = new EventoDao();
			var evento = eventoDao.GetById(id);

			if (evento != null)
			{
				return true;
			}
			else
				return false;
		}
	}
}
