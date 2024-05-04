using BLL;
using ENTITY.DTO;
using ENTITY;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISTEMA.API.DBContextDapper;

namespace SISTEMA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController(DapperCNN _DapperCNN) : ControllerBase
{
    [HttpPost]
    [Route("Guardar")]
    public IActionResult Guardar([FromBody] CLIENTE cliente)
    {

        List<string> lstValidaciones = BLL_CLIENTE.ValidacionDatos(_DapperCNN.Connection(), cliente, 1);

        if (lstValidaciones.Count == 0)
        {
            List<string> lstDatos = BLL_CLIENTE.GuardarDatos(_DapperCNN.Connection(), cliente);

            if (lstDatos[0] == "00")
            {
                return Ok(new { Estatus = "00", Mensaje = lstDatos[1] });
            }
            else
            {
                return Ok(new { Estatus = lstDatos[0], Mensaje = lstDatos[1] });
            }
        }
        else
        {
            return Ok(new { Estatus = 14, Mensaje = lstValidaciones[0] });
        }
    }

    [HttpGet]
    [Route("ListarClientes")]
    public IActionResult ListarClientes()
    {
        List<DtoConsultaCliente> ltsConsulcliente = BLL_CLIENTE.ConsultaCliente(_DapperCNN.Connection());

        if (ltsConsulcliente.Count > 0)
        {
            return Ok(new { status = "00", value = ltsConsulcliente });
        }
        else
        {
            return BadRequest(new { status = 14, value = "" });
        }
    }

    [HttpGet]
    [Route("ListarClientes/Texto")]
    public IActionResult ListarClientes(string Texto)
    {
        List<DtoConsultaCliente> ltsConsulcliente = BLL_CLIENTE.ConsultaCliente(_DapperCNN.Connection(), Texto);

        if (ltsConsulcliente.Count > 0)
        {
            return Ok(new { status = "00", value = ltsConsulcliente });
        }
        else
        {
            return BadRequest(new { status = 14, value = "" });
        }
    }

    [HttpPut]
    [Route("Editar")]
    public IActionResult Editar([FromBody] CLIENTE cliente)
    {
        List<string> lstValidaciones = BLL_CLIENTE.ValidacionDatos(_DapperCNN.Connection(), cliente, 2);

        if (lstValidaciones.Count == 0)
        {
            List<string> lstDatos = BLL_CLIENTE.ActualizarDatos(_DapperCNN.Connection(), cliente);

            if (lstDatos[0] == "00")
            {
                return Ok(new { Estatus = "00", Mensaje = lstDatos[1] });
            }
            else
            {
                return Ok(new { Estatus = lstDatos[0], Mensaje = lstDatos[1] });
            }
        }
        else
        {
            return Ok(new { Estatus = 14, Mensaje = lstValidaciones[0] });
        }
    }


}
