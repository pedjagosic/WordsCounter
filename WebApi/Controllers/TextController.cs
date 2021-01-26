using System.Collections.Generic;
using Application.Text.Commands;
using Application.Text.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Dto;

namespace WebApi.Controllers
{
    public class TextController : BaseController
    {
        [HttpGet]
        public async Task<int> Get([FromQuery] string typeId, string text, string id)
        {
            return await Mediator.Send(new GetTextQuery(typeId, text, id));
        }

        [HttpGet]
        public async Task<IEnumerable<TextDto>> GetAll()
        {
            return await Mediator.Send(new GetAllTextsQuery());
        }

        [HttpPost]
        public async Task<int> Post(string text)
        {
            return await Mediator.Send(new AddTextCommand(text));
        }
    }
}