using Hermoza.BibloMax.Servicios.General.Dtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Hermoza.BibloMax.Servicios.General.Utilitarios
{
    public class CorreoUtiliario
    {
        public static bool EnviarCorreo(string asunto, List<string> destinatarios, string cuerpo)
        {
            var val = true;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("joeantoni.hermoza@gmail.com", "audioslave"),
                Timeout = 20000
            };

            using (var message = new MailMessage()
            {
                From = new MailAddress("joeantoni.hermoza@gmail.com"),
                Subject = asunto,
                Body = cuerpo
            })
            {
                message.IsBodyHtml = true;
                destinatarios.ForEach(e => message.To.Add(e));

                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    val = false;

                    throw new Exception("No se ha podido enviar el  email: " + ex.Message);

                }
                finally
                {
                    smtp.Dispose();
                }

            }

            return val;
        }


        public static bool EnviarCorreo(CorreoParametrosDto peticion)
        {
            var val = true;

            var smtp = new SmtpClient
            {
                Host = peticion.Host,
                Port = peticion.Port,
                EnableSsl = peticion.EnableSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(peticion.UsuarioSmtp, peticion.PasswordSmtp),
                Timeout = 20000
            };

            using (var message = new MailMessage()
            {
                From = new MailAddress(peticion.From),
                Subject = peticion.Asunto,
                Body = peticion.Cuerpo
            })
            {
                message.IsBodyHtml = true;
                peticion.To.ForEach(e => message.To.Add(e));

                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    val = false;
                }
                finally
                {
                    smtp.Dispose();
                }

            }

            return val;
        }
    }
}
