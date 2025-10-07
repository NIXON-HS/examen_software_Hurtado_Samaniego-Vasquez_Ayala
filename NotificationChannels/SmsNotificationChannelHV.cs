using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.NotificationChannels
{
    /// <summary>
    /// SRP: Envía notificaciones simuladas por SMS.
    /// </summary>
    public class SmsNotificationChannelHV : INotificationChannel_HV, IRecipientNotification_HV, IRecipientDestination_HV
    {
        public string ChannelName_HV => "SMS";

        public NotificationResult_HV SendNotification_HV(string message_HV)
        {
            return CreateResult_HV(message_HV, "000000000");
        }

        public NotificationResult_HV SendToRecipient_HV(string message_HV, string recipient_HV)
        {
            return CreateResult_HV(message_HV, recipient_HV);
        }

        public string ExtractDestination_HV(RecipientInfo_HV recipient_HV)
        {
            return recipient_HV == null ? string.Empty : recipient_HV.PhoneNumber_HV;
        }

        private NotificationResult_HV CreateResult_HV(string message_HV, string recipient_HV)
        {
            var normalizedRecipient_HV = string.IsNullOrWhiteSpace(recipient_HV) ? "sin-numero" : recipient_HV;

            return new NotificationResult_HV
            {
                IsSuccessful_HV = !string.IsNullOrWhiteSpace(recipient_HV),
                Message_HV = string.IsNullOrWhiteSpace(recipient_HV)
                    ? "No se pudo enviar SMS: número vacío."
                    : "SMS enviado correctamente.",
                Channel_HV = ChannelName_HV + " -> " + normalizedRecipient_HV,
                SentAt_HV = DateTime.Now
            };
        }
    }
}
