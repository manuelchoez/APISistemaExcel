using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Applicacion.Util
{
    public class Response<TResponse>
    {
        public HttpStatusCode Status { get; }
        public bool EsError { get; }
        public TResponse Result { get; set; }
        public string Descripcion { get; set; }
        public object Mensaje { get; set; }
        public string IdSesion { get; set; }
        public string Secuencial { get; set; }
        public Response(TResponse response, object mensaje)
        {
            Result = response;
            EsError = false;
            Mensaje = mensaje;
            Status = HttpStatusCode.OK;
        }

        protected Response(TResponse response, string descripcion, string idSesion, string secuencial)
        {
            Result = response;
            EsError = false;
            Descripcion = descripcion;
            IdSesion = idSesion;
            Secuencial = secuencial;
            Status = HttpStatusCode.OK;
        }
        protected Response(Exception errors)
        {
            Mensaje = errors.Message;
            EsError = true;
            Status = HttpStatusCode.InternalServerError;
        }

        protected Response(Exception errors, string descripcion, string idSesion, string secuencial)
        {
            Mensaje = errors.Message;
            Descripcion = descripcion;
            IdSesion = idSesion;
            Secuencial = secuencial;
            EsError = true;
            Status = HttpStatusCode.InternalServerError;
        }

        protected Response(object mensajeControlado)
        {
            Mensaje = mensajeControlado;
            EsError = false;
            Status = HttpStatusCode.OK;
        }

        protected Response(object mensajeControlado, string descripcion, string idSesion, string secuencial)
        {
            Mensaje = mensajeControlado;
            Descripcion = descripcion;
            IdSesion = idSesion;
            Secuencial = secuencial;
            EsError = false;
            Status = HttpStatusCode.OK;
        }
        public static Response<TResponse> Error(Exception error)
        {
            return new Response<TResponse>(error);
        }

        public static Response<TResponse> Error(Exception error, string descripcion, string idSesion, string secuencial)
        {
            return new Response<TResponse>(error, descripcion, idSesion, secuencial);
        }

        public static Response<TResponse> Ok(TResponse response, object mensaje)
        {
            return new Response<TResponse>(response, mensaje);
        }

        public static Response<TResponse> Ok(TResponse response, string descripcion, string idSesion, string secuencial)
        {
            return new Response<TResponse>(response, descripcion, idSesion, secuencial);
        }

        public static Response<TResponse> Warning(object mensajeControlado)
        {
            return new Response<TResponse>(mensajeControlado);
        }

        public static Response<TResponse> Warning(object mensajeControlado, string descripcion, string idSesion, string secuencial)
        {
            return new Response<TResponse>(mensajeControlado, descripcion, idSesion, secuencial);
        }
    }
    
}
