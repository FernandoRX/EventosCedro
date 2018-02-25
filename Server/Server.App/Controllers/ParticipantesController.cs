using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Bll;
using Server.Dal.ModelView;

namespace Server.App.Controllers
{
    [Route("api/Participantes")]
    public class ParticipantesController : Controller
    {
		[HttpPost]
		public IActionResult Post([FromBody]ParticipanteModelView participanteModelView)
		{
			try
			{
				var participanteBll = new ParticipanteBll();
				var eventoBll = new EventoBll();
				var Verify = eventoBll.VerificaSeTemIngresso(participanteModelView.IdEvento);
				if (Verify == true)
				{
					participanteBll.Create(participanteModelView);
					return NoContent();
				}
				else
					return StatusCode(500, "Acabaram os ingressos");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500);
			}
		}

		[HttpGet]
		public IActionResult GetParticipantes()
		{
			try
			{
				var participanteBll = new ParticipanteBll();
				var ListParticipantes = participanteBll.GetParticipantes();
				return Json(ListParticipantes);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500);
			}

		}

		[HttpGet("{id}")]
		public IActionResult GetById([FromRoute]int id)
		{
			try
			{
				var participanteBll = new ParticipanteBll();
				var participante = participanteBll.GetById(id);
				return Ok(participante);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete([FromRoute]int id)
		{
			try
			{
				var participanteBll = new ParticipanteBll();
				participanteBll.Delete(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500);
			}
		}

		[HttpPut("{id}")]
		public IActionResult Put([FromRoute]int id, [FromBody] ParticipanteModelView participanteModelView)
		{
			try
			{
				var participanteBll = new ParticipanteBll();
				participanteBll.Update(id, participanteModelView);
				return NoContent();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500);
			}

		}
	}
}