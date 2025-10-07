using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.NotificationChannels
{
    /// <summary>
    /// SRP: Envía notificaciones simuladas por WhatsApp.
    /// </summary>
    public class WhatsAppNotificationChannelHV : INotificationChannel, IRecipientNotification, IRecipientDestination
    {
        public string ChannelName => "WhatsApp";

        public NotificationResult_HV SendNotification_HV(string Message)
        {
            return CreateResult_HV(Message, "sin-destino");
        }

        public NotificationResult_HV SendToRecipient_HV(string message, string recipient)
        {
            return CreateResult_HV(message, recipient);
        }

        public string ExtractDestination_HV(RecipientInfo_HV Recipient)
        {
            return Recipient == null ? string.Empty : Recipient.WhatsappNumber;
        }

        private NotificationResult_HV CreateResult_HV(string Message, string Recipient)
        {
            var normalizedRecipient = string.IsNullOrWhiteSpace(Recipient) ? "sin-whatsapp" : Recipient;

            return new NotificationResult_HV
            {
                IsSuccessful = !string.IsNullOrWhiteSpace(Recipient),
                Message = string.IsNullOrWhiteSpace(Recipient)
                    ? "No se pudo enviar WhatsApp: número vacío."
                    : "Mensaje de WhatsApp enviado correctamente.",
                Channel = ChannelName + " -> " + normalizedRecipient,
                SentAt = DateTime.Now
            };
        }
    }
}
