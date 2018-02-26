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
    [Route("api/Eventos")]
    public class EventosController : Controller
    {
		[HttpPost]
		public IActionResult Post([FromBody]EventoModelView eventoModelView)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				var eventoBll = new EventoBll();
				eventoBll.Create(eventoModelView);
				return NoContent();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500);
			}
		}

		[HttpGet]
		public IActionResult GetEventos()
		{
			try
			{
				var eventoBll = new EventoBll();
				var ListEventos = eventoBll.GetEventos();
				return Json(ListEventos);
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
				var eventoBll = new EventoBll();
				var evento = eventoBll.GetById(id);
				return Json(evento);
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
				var eventoBll = new EventoBll();
				eventoBll.Delete(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(500);
			}
		}

		[HttpPut("{id}")]
		public IActionResult Put([FromRoute]int id, [FromBody] EventoModelView eventoModelView)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				var eventoBll = new EventoBll();
				eventoBll.Update(id, eventoModelView);
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