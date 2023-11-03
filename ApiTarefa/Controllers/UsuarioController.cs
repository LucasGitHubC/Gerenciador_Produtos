using ApiTarefa.Model;
using ApiTarefa.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTarefa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepository;

        public UsuarioController(IUsuarioRepositorio usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            try
            {
                var usuarios = await _usuarioRepository.BuscarTodosUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarPorId(int Id)
        {
            UsuarioModel usuario = await _usuarioRepository.BuscarporId (Id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<List<UsuarioModel>>> Cadastrar ([FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UsuarioModel usuario = await _usuarioRepository.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut]
        public async Task<ActionResult<List<UsuarioModel>>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepository.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<UsuarioModel>>> Apagar(int id)
        {
            bool apagado = await _usuarioRepository.Apagar(id);
            return Ok(apagado);
        }
    }
}

