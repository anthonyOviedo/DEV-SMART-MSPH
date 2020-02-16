using Business.Models;
using Business.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Business.Utilities.Functions;


namespace ControlClaro.Controllers
{
    public class FormController : ApiController
    {

        #region Definition of Services
        [HttpGet]
        [Route("api/form/lista/{departmentId}")]
        public HttpResponseMessage Lista(int departmentId)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            ResponseConfig config = VerifyAuthorization(Request.Headers);
            RestResponse data = new RestResponse();

            try
            {
                VerifyMessage(config.errorMessage);

                //if (criterio == "_TODO_")
                //    criterio = "";

                using (FormServices service = new FormServices() )
                {
                   
                    data.result = service.Lista(departmentId);
                    data.status = true;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = config.isAuthenticated ? HttpStatusCode.BadRequest : HttpStatusCode.Unauthorized;
                data.status = false;
                data.message = ex.Message;
                data.error = NewError(ex, "Lista de formularios");
            }
            finally
            {
                response.Content = CreateContent(data);
            }

            return response;
        }



        [HttpDelete]
        [Route("api/form/eliminar/{id}")]
        public HttpResponseMessage Eliminar(string id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            ResponseConfig config = VerifyAuthorization(Request.Headers);
            RestResponse data = new RestResponse();

            try
            {
                VerifyMessage(config.errorMessage);

                using (UsuarioService service = new UsuarioService())
                {
                    service.Eliminar(id);
                    data.result = null;
                    data.status = true;
                    data.message = "El formulario seleccionado se eliminó correctamente";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = config.isAuthenticated ? HttpStatusCode.BadRequest : HttpStatusCode.Unauthorized;
                data.status = false;
                data.message = ex.Message;
                data.error = NewError(ex, "Eliminar fomulario");
            }
            finally
            {
                response.Content = CreateContent(data);
            }

            return response;
        }


        [HttpPost]
        [Route("api/form/change-password/{newPassword}")]
        public HttpResponseMessage ChangePassword([FromBody] Usuario usuario, string newPassword)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            ResponseConfig config = VerifyAuthorization(Request.Headers);
            RestResponse data = new RestResponse();

            try
            {
                VerifyMessage(config.errorMessage);

                using (UsuarioService service = new UsuarioService())
                {
                    service.ChangePassword(usuario.usuario_Id, usuario.password, newPassword);
                    data.result = null;
                    data.status = true;
                    data.message = "El cambio de contraseña se completó correctamente";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = config.isAuthenticated ? HttpStatusCode.BadRequest : HttpStatusCode.Unauthorized;
                data.status = false;
                data.message = ex.Message;
                data.error = NewError(ex, "Cambio de contraseña");
            }
            finally
            {
                response.Content = CreateContent(data);
            }

            return response;
        }
        #endregion


    }
}