using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PontoEletronico.API.Dtos;
using PontoEletronico.Domain;
using PontoEletronico.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using PontoEletronico.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace PontoEletronico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PontoRegistroController : ControllerBase
    {
        private IPontoEletronicoRepository Context { get; }
        private readonly IMapper _mapper;

        public PontoRegistroController(IPontoEletronicoRepository context, IMapper mapper)
        {
            this._mapper = mapper;
            this.Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pontos = await Context.GetAllPontoRegistroAsync();
                var result = _mapper.Map<PontoRegistroDto[]>(pontos);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro Interno API - " + ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(PontoRegistroDto model)
        {
            try
            {
                var pontos = _mapper.Map<PontoRegistro>(model);
                Context.Add(pontos);

                if (await Context.SaveChangesAsync())
                {
                    return Created($"pontos{model.Id}", model);
                }

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro Interno API -  {ex.Message} ");
            }

            return BadRequest();
        }

        [Route("{PontoId:Guid}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid PontoId)
        {
            try
            {
                var ponto = await Context.GetAllPontoAsyncById(PontoId);

                if (ponto == null)
                {
                    return NotFound();
                }

                Context.Delete(ponto);

                if (await Context.SaveChangesAsync())
                {
                    return Created($"pontos{ponto.Id}", ponto);
                }

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro Interno API -  {ex.Message} ");
            }

            return BadRequest();
        }

    }
}