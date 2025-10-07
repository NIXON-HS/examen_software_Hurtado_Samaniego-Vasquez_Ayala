using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.NotificationChannels
{
    /// <summary>
    /// SRP: Envía notificaciones simuladas por WhatsApp.
    /// </summary>
    public class WhatsAppNotificationChannelHV : INotificationChannel_HV, IRecipientNotification_HV, IRecipientDestination_HV
    {
        public string ChannelName_HV => "WhatsApp";

        public NotificationResult_HV SendNotification_HV(string message_HV)
        {
            return CreateResult_HV(message_HV, "sin-destino");
        }

        public NotificationResult_HV SendToRecipient_HV(string message_HV, string recipient_HV)
        {
            return CreateResult_HV(message_HV, recipient_HV);
        }

        public string ExtractDestination_HV(RecipientInfo_HV recipient_HV)
        {
            return recipient_HV == null ? string.Empty : recipient_HV.WhatsappNumber_HV;
        }

        private NotificationResult_HV CreateResult_HV(string message_HV, string recipient_HV)
        {
            var normalizedRecipient_HV = string.IsNullOrWhiteSpace(recipient_HV) ? "sin-whatsapp" : recipient_HV;

            return new NotificationResult_HV
            {
                IsSuccessful_HV = !string.IsNullOrWhiteSpace(recipient_HV),
                Message_HV = string.IsNullOrWhiteSpace(recipient_HV)
                    ? "No se pudo enviar WhatsApp: número vacío."
                    : "Mensaje de WhatsApp enviado correctamente.",
                Channel_HV = ChannelName_HV + " -> " + normalizedRecipient_HV,
                SentAt_HV = DateTime.Now
            };
        }
    }
}
