using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.NotificationChannels
{
    /// <summary>
    /// SRP: Envía notificaciones simuladas por SMS.
    /// </summary>
    public class SmsNotificationChannelHV : INotificationChannel, IRecipientNotification, IRecipientDestination
    {
        public string ChannelName => "SMS";

        public NotificationResult_HV SendNotification_HV(string Message)
        {
            return CreateResult_HV(Message, "000000000");
        }

        public NotificationResult_HV SendToRecipient_HV(string message, string recipient)
        {
            return CreateResult_HV(message, recipient);
        }

        public string ExtractDestination_HV(RecipientInfo_HV Recipient)
        {
            return Recipient == null ? string.Empty : Recipient.PhoneNumber;
        }

        private NotificationResult_HV CreateResult_HV(string Message, string Recipient)
        {
            var normalizedRecipient = string.IsNullOrWhiteSpace(Recipient) ? "sin-numero" : Recipient;

            return new NotificationResult_HV
            {
                IsSuccessful = !string.IsNullOrWhiteSpace(Recipient),
                Message = string.IsNullOrWhiteSpace(Recipient)
                    ? "No se pudo enviar SMS: número vacío."
                    : "SMS enviado correctamente.",
                Channel = ChannelName + " -> " + normalizedRecipient,
                SentAt = DateTime.Now
            };
        }
    }
}
