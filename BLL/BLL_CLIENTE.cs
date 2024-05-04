using ENTITY.DTO;
using ENTITY;
using System.Data;
using DAL;
using FluentValidation;
using BLL.Validaciones;

namespace BLL;

public class BLL_CLIENTE
{

    public static List<string> ValidacionDatos(string Cadena, CLIENTE PCliente, int opc)
    {
        List<string> lstValidaciones = [];

        ClientesValidaciones clienteValidacion = new();

        var ClienteResultado = clienteValidacion.Validate(PCliente);

        if (!ClienteResultado.IsValid)
        {
            lstValidaciones = ClienteResultado.Errors.Select(x => x.ErrorMessage).ToList();
        }

        if (opc == 1)
        {
            if (ValidaNombreCliente(Cadena, PCliente.Nombre, PCliente.APaterno, PCliente.AMaterno, PCliente.RCF))
            {
                lstValidaciones.Add("Los datos del cliente, ya fueron registrados previamente");
            }
        }

        return lstValidaciones;
    }

    private static bool ValidaNombreCliente(string Cadena, string Nombre, string APaterno, string AMaterno, string RFC)
    {
        bool Validacion = false;

        var dpParametros = new
        {
            P_Accion = 1,
            P_Nombre = Nombre,
            P_APaterno = APaterno,
            P_AMaterno = AMaterno,
            P_RFC = RFC
        };

        DataTable Dt = Context.Funcion_StoreDB(Cadena, "spConsulValidaCliente", dpParametros);

        if (Dt.Rows.Count > 0)
        {
            Validacion = true;
        }
        return Validacion;
    }

    public static List<string> GuardarDatos(string Cadena, CLIENTE PCliente)
    {
        List<string> lstDatos = [];
        try
        {
            var dpParemtros = new
            {
                P_Nombre = PCliente.Nombre.ToUpper(),
                P_APaterno = PCliente.APaterno.ToUpper(),
                P_AMaterno = PCliente.AMaterno.ToUpper(),
                P_RFC = PCliente.RCF.ToUpper()
            };

            Context.Procedimiento_StoreDB(Cadena, "spInsertCliente", dpParemtros);
            lstDatos.Add("00");
            lstDatos.Add("Cliente Guardado con éxito");
        }
        catch (Exception e)
        {
            lstDatos.Add("14");
            lstDatos.Add(e.Message);
        }
        return lstDatos;
    }

    public static List<DtoConsultaCliente> ConsultaCliente(string Cadena)
    {
        List<DtoConsultaCliente> ltsConsulcliente = [];

        var dpParametros = new
        {
            P_Accion = 1
        };

        DataTable Dt = Context.Funcion_StoreDB(Cadena, "spConsultaCliente", dpParametros);

        if (Dt.Rows.Count > 0)
        {
            ltsConsulcliente =
            [
                .. (from item in Dt.AsEnumerable()
                    select new DtoConsultaCliente
                    {
                        IdCliente = item.Field<int>("IdCliente"),
                        Cliente = item.Field<string>("Cliente"),
                        RFC = item.Field<string>("RFC"),
                        FecRegistro = item.Field<string>("FecRegistro"),
                        Estatus = item.Field<string>("Estatus")
                    }),
            ];
        }
        return ltsConsulcliente;
    }

    public static List<DtoConsultaCliente> ConsultaCliente(string Cadena, string Texto)
    {
        List<DtoConsultaCliente> ltsConsulcliente = [];

        var dpParametros = new
        {
            P_Accion = 2,
            P_Texto = Texto
        };

        DataTable Dt = Context.Funcion_StoreDB(Cadena, "spConsultaCliente", dpParametros);

        if (Dt.Rows.Count > 0)
        {
            ltsConsulcliente =
            [
                .. (from item in Dt.AsEnumerable()
                    select new DtoConsultaCliente
                    {
                        IdCliente = item.Field<int>("IdCliente"),
                        Cliente = item.Field<string>("Cliente"),
                        RFC = item.Field<string>("RFC"),
                        FecRegistro = item.Field<string>("FecRegistro"),
                        Estatus = item.Field<string>("Estatus")
                    }),
            ];
        }

        return ltsConsulcliente;
    }

    public static List<string> ActualizarDatos(string Cadena, CLIENTE PCliente)
    {
        List<string> lstDatos = [];
        try
        {
            var dpParemtros = new
            {
                P_Nombre = PCliente.Nombre.ToUpper(),
                P_APaterno = PCliente.APaterno.ToUpper(),
                P_AMaterno = PCliente.AMaterno.ToUpper(),
                P_RFC = PCliente.RCF.ToUpper(),
                P_IdCliente = PCliente.IdCliente,
                P_IsActivo = PCliente.Estatus
            };

            Context.Procedimiento_StoreDB(Cadena, "spActualiCliente", dpParemtros);
            lstDatos.Add("00");
            lstDatos.Add("Cliente Actualizado con éxito");
        }
        catch (Exception e)
        {
            lstDatos.Add("14");
            lstDatos.Add(e.Message);
        }
        return lstDatos;
    }

}
