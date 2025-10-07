using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.NotificationChannels
{
    /// <summary>
    /// SRP: Envía notificaciones por correo electrónico.
    /// </summary>
    public class EmailNotificationChannelHV : INotificationChannel, IRecipientNotification, IRecipientDestination
    {
        public string ChannelName => "Correo Electrónico";

        /// <summary>
        /// Permite mensajes generales sin destinatario concreto.
        /// </summary>
        public NotificationResult_HV SendNotification_HV(string Message)
        {
            return CreateResult_HV(Message, "contacto@sin-destinatario.com");
        }

        /// <summary>
        /// Envía un correo al destinatario especificado.
        /// </summary>
        public NotificationResult_HV SendToRecipient_HV(string message, string recipient)
        {
            return CreateResult_HV(message, recipient);
        }

        public string ExtractDestination_HV(RecipientInfo_HV Recipient)
        {
            return Recipient == null ? string.Empty : Recipient.Email;
        }

        private NotificationResult_HV CreateResult_HV(string Message, string Recipient)
        {
            var normalizedRecipient = string.IsNullOrWhiteSpace(Recipient) ? "sin-correo" : Recipient;

            return new NotificationResult_HV
            {
                IsSuccessful = !string.IsNullOrWhiteSpace(Recipient),
                Message = string.IsNullOrWhiteSpace(Recipient)
                    ? "No se pudo enviar correo: destinatario vacío."
                    : "Correo enviado correctamente.",
                Channel = ChannelName + " -> " + normalizedRecipient,
                SentAt = DateTime.Now
            };
        }
    }
}
