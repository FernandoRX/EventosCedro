using Server.Dal.DataAccessObject;
using Server.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Server.Bll
{
    public class EmailBll
    {

		public void SendEmailWhenRegisters(Participante participante)
		{
			var eventoDao = new EventoDao();
			var evento = eventoDao.GetById(participante.IdEvento);
			MailMessage mail = new MailMessage();
			mail.To.Add(new MailAddress(participante.Email));
			mail.From = new MailAddress("CadastroEventos00@hotmail.com");
			mail.Subject = "Cadastro no evento " + evento.Nome;
			mail.IsBodyHtml = true;
			mail.Body = "" + participante.Nome + ",</br> Seu cadastro para o evento " + evento.Nome + " foi concluido com sucesso !";

			SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
			using (client)
			{
				client.Credentials = new System.Net.NetworkCredential("CadastroEventos00@hotmail.com", "cedro123");
				client.EnableSsl = true;
				try
				{
					client.Send(mail);
				}
				catch (Exception ex)
				{
					Console.Write("Não foi possivel enviar o email, Erro = " + ex.Message);
				}
			}
		}

		public void SendMailWhenEventoDelete(int id)
		{
			var eventoBll = new EventoDao();
			var evento = eventoBll.GetById(id);
			var participanteBll = new ParticipanteBll();
			var listParticipantes = participanteBll.GetParticipantes();

			foreach (var participante in listParticipantes)
			{
				if (participante.IdEvento != evento.IdEvento)
				{
					continue;
				}
				MailMessage mail = new MailMessage();
				mail.To.Add(new MailAddress(participante.Email));
				mail.From = new MailAddress("CadastroEventos00@hotmail.com");
				mail.Subject = "Alterações no evento  " + evento.Nome;
				mail.IsBodyHtml = true;
				mail.Body = "" + participante.Nome + ",<br/> Seu evento " + evento.Nome + " foi cancelado, entre em contato para mais detalhes";

				SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
				using (client)
				{
					client.Credentials = new System.Net.NetworkCredential("CadastroEventos00@hotmail.com", "cedro123");
					client.EnableSsl = true;
					try
					{
						client.Send(mail);
					}
					catch (Exception ex)
					{
						Console.Write("Não foi possivel enviar o email, Erro = " + ex.Message);
					}
				}
			}
		}

		public void SendMailWhenEventoUpdate(Evento evento)
		{
			var participanteBll = new ParticipanteBll();
			var listParticipantes = participanteBll.GetParticipantes();

			foreach (var participante in listParticipantes)
			{
				if (participante.IdEvento != evento.IdEvento)
				{
					continue;
				}
				MailMessage mail = new MailMessage();
				mail.To.Add(new MailAddress(participante.Email));
				mail.From = new MailAddress("CadastroEventos00@hotmail.com");
				mail.Subject = "Alterações no evento  " + evento.Nome;
				mail.IsBodyHtml = true;
				mail.Body = "" + participante.Nome + ",<br/> Aconteceram modificações no seu evento " + evento.Nome + ", entre em contato para mais detalhes";

				SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
				using (client)
				{
					client.Credentials = new System.Net.NetworkCredential("CadastroEventos00@hotmail.com", "cedro123");
					client.EnableSsl = true;
					try
					{
						client.Send(mail);
					}
					catch (Exception ex)
					{
						Console.Write("Não foi possivel enviar o email, Erro = " + ex.Message);
					}
				}
			}
		}
	}
}
