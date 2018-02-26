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
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				var participanteBll = new ParticipanteBll();
				var mensagem = participanteBll.Create(participanteModelView);
				return Ok(mensagem);
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
				return Json(participante);
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
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				var participanteBll = new ParticipanteBll();
				var mensagem = participanteBll.Update(id, participanteModelView);
				return Ok(mensagem);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500);
			}

		}
	}
}