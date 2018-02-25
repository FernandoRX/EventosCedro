using Server.Dal.DataAccessObject;
using Server.Dal.Models;
using Server.Dal.ModelView;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Bll
{
    public class EventoBll
    {
		public List<Evento> GetEventos()
		{
			var eventoDao = new EventoDao();
			return eventoDao.GetEventos();
		}

		public Evento GetById(int id)
		{
			var eventoDao = new EventoDao();
			return eventoDao.GetById(id);
		}

		public void Create(EventoModelView eventoModelView)
		{
			var evento = new Evento();
			evento = PrepareEvento(eventoModelView, evento);
			var eventoDao = new EventoDao();
			eventoDao.Create(evento);
		}

		public void Delete(int id)
		{
			var eventoDao = new EventoDao();
			eventoDao.Delete(id);
		}

		public void Update(int id, EventoModelView eventoModelView)
		{
			var eventoDao = new EventoDao();
			var evento = eventoDao.GetById(id);
			evento = PrepareEvento(eventoModelView, evento);
			eventoDao.Update(evento);
		}

		public Evento PrepareEvento(EventoModelView eventoModelView, Evento evento)
		{
			
			evento.Data = eventoModelView.Data;
			evento.HoraFim = eventoModelView.HoraFim;
			evento.HoraInicio = eventoModelView.HoraInicio;
			evento.Local = eventoModelView.Local;
			evento.Nome = eventoModelView.Nome;
			evento.OpenBar = eventoModelView.OpenBar;
			evento.QuantidadeDeAmbientes = eventoModelView.QuantidadeDeAmbientes;
			evento.MaximoIngressos = eventoModelView.MaximoIngressos;

			if (evento.HoraInicio > 10 && evento.HoraFim < 20 && evento.QuantidadeDeAmbientes > 2)
			{
				evento.FaixaEtaria = "Menor que 16 anos";
			}
			else if (evento.HoraInicio > 20 && evento.HoraFim < 2 && evento.OpenBar == false)
			{
				evento.FaixaEtaria = "Maior que 16 anos";
			}
			else
				evento.FaixaEtaria = "Maior que 18 anos";

			return evento;
		}
	}
}
