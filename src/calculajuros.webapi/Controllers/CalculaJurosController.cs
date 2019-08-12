using CalculaJuros.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace CalculaJuros.WebApi.Controllers
{
    [Route("calculajuros")]
    public class CalculaJurosController : BaseController
    {
        private readonly ICalculaJurosService _calculaJurosService;

        public CalculaJurosController(ICalculaJurosService calculaJurosService) : base()
        {
            _calculaJurosService = calculaJurosService;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [SwaggerOperation(Summary = "Retorna Calculo Juros", Tags = new[] { "Calcula Juros" })]
        public IActionResult GetCalculaJuros([FromQuery][BindRequired] decimal valorInicial, [FromQuery][BindRequired] int tempo)
        {
            try
            {
                var calculoJuros = _calculaJurosService.RetornarCalculoJuros(valorInicial, tempo);

                return RequestResponse(HttpStatusCode.OK, result: JsonConvert.SerializeObject(calculoJuros));
            }
            catch
            {
                return RequestResponse(HttpStatusCode.BadRequest, isError: true, result: "Ocorreu um erro ao retornar o calculo dos juros");
            }
        }

        [HttpGet("showmethecode")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [SwaggerOperation(Summary = "Link para Código Fonte", Tags = new[] { "Calcula Juros" })]
        public IActionResult ShowmeTheCode()
        {
            return RequestResponse(HttpStatusCode.OK, result: "https://github.com/dycorrales/softplan-calculajuros");
        }

        [HttpGet("healthcheck")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [SwaggerOperation(Summary = "Retorna OK", Tags = new[] { "Calcula Juros" })]
        public IActionResult GetOk()
        {
            return RequestResponse(HttpStatusCode.OK);
        }
    }
}
