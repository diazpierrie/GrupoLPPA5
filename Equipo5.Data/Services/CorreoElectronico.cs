using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Equipo5.Data.Services
{
    public class CorreoElectronico
    {
        public static void BienvenidaUsuario(string nombre, string correoElectronico)
        {
            //TODO
            var body = "";
            var subject = "Bienvenida Usuario New Market";
            EnviarMail(subject, body, correoElectronico);
        }

        public static void RecuperarPassword(string nombre, string nuevoPassword, string correoElectronico)
        {
            //TODO
            var body = "Hola " + nombre + " tu nueva contraseña es: " + nuevoPassword + " ";
            var subject = "Recuperacion de Contraseña";
            EnviarMail(subject, body, correoElectronico);
        }
        public static void EnviarMail(string subject, string body, string correoElectronico)
        {
            var _Message = new MailMessage();
            var _SMTP = new SmtpClient();

            //Configuracion SMTP
            _SMTP.Credentials = new NetworkCredential("lppa.grupo6.2021@gmail.com", "Equipo5.2021");
            _SMTP.Host = "smtp.gmail.com";
            _SMTP.Port = 587;
            _SMTP.EnableSsl = true;

            //Configuracion Mensaje
            _Message.To.Add(correoElectronico);
            _Message.From = new MailAddress("lppa.grupo6.2021@gmail.com");
            _Message.Subject = subject;
            _Message.Body = body;
            _Message.Priority = MailPriority.Normal;


            try
            {
                _SMTP.Send(_Message);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
