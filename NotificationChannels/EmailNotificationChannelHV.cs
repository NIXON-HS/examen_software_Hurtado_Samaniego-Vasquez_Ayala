using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.NotificationChannels
{
    /// <summary>
    /// SRP: Envía notificaciones por correo electrónico.
    /// </summary>
    public class EmailNotificationChannelHV : INotificationChannel_HV, IRecipientNotification_HV, IRecipientDestination_HV
    {
        public string ChannelName_HV => "Correo Electrónico";

        /// <summary>
        /// Permite mensajes generales sin destinatario concreto.
        /// </summary>
        public NotificationResult_HV SendNotification_HV(string message_HV)
        {
            return CreateResult_HV(message_HV, "contacto@sin-destinatario.com");
        }

        /// <summary>
        /// Envía un correo al destinatario especificado.
        /// </summary>
        public NotificationResult_HV SendToRecipient_HV(string message_HV, string recipient_HV)
        {
            return CreateResult_HV(message_HV, recipient_HV);
        }

        public string ExtractDestination_HV(RecipientInfo_HV recipient_HV)
        {
            return recipient_HV == null ? string.Empty : recipient_HV.Email_HV;
        }

        private NotificationResult_HV CreateResult_HV(string message_HV, string recipient_HV)
        {
            var normalizedRecipient_HV = string.IsNullOrWhiteSpace(recipient_HV) ? "sin-correo" : recipient_HV;

            return new NotificationResult_HV
            {
                IsSuccessful_HV = !string.IsNullOrWhiteSpace(recipient_HV),
                Message_HV = string.IsNullOrWhiteSpace(recipient_HV)
                    ? "No se pudo enviar correo: destinatario vacío."
                    : "Correo enviado correctamente.",
                Channel_HV = ChannelName_HV + " -> " + normalizedRecipient_HV,
                SentAt_HV = DateTime.Now
            };
        }
    }
}
