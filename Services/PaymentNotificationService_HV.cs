using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Services
{
    /// <summary>
    /// SRP: Coordina el envío de notificaciones tras un pago.
    /// DIP: Depende de interfaces de canales de notificación.
    /// </summary>
    public class PaymentNotificationService_HV : IPaymentNotificationService_HV
    {
        private readonly INotificationChannel_HV[] _channels_HV;

        public PaymentNotificationService_HV(INotificationChannel_HV[] channels_HV)
        {
            _channels_HV = channels_HV ?? new INotificationChannel_HV[0];
        }

        /// <summary>
        /// Envía el resultado usando todos los canales disponibles.
        /// </summary>
        public NotificationResult_HV[] NotifyPaymentResult_HV(PaymentResult_HV paymentResult_HV, RecipientInfo_HV recipient_HV)
        {
            var channelsLength_HV = _channels_HV.Length;
            var results_HV = new NotificationResult_HV[channelsLength_HV];

            for (var index_HV = 0; index_HV < channelsLength_HV; index_HV++)
            {
                var channel_HV = _channels_HV[index_HV];
                var message_HV = BuildMessage_HV(paymentResult_HV);

                if (channel_HV is IRecipientNotification_HV recipientChannel_HV && channel_HV is IRecipientDestination_HV destinationResolver_HV)
                {
                    var destination_HV = destinationResolver_HV.ExtractDestination_HV(recipient_HV);

                    if (string.IsNullOrWhiteSpace(destination_HV))
                    {
                        results_HV[index_HV] = new NotificationResult_HV
                        {
                            IsSuccessful_HV = false,
                            Message_HV = "No se encontró un contacto válido para este canal.",
                            Channel_HV = channel_HV.ChannelName_HV,
                            SentAt_HV = DateTime.Now
                        };
                        continue;
                    }

                    results_HV[index_HV] = recipientChannel_HV.SendToRecipient_HV(message_HV, destination_HV);
                }
                else
                {
                    results_HV[index_HV] = channel_HV.SendNotification_HV(message_HV);
                }
            }

            return results_HV;
        }

        private static string BuildMessage_HV(PaymentResult_HV paymentResult_HV)
        {
            if (paymentResult_HV == null)
            {
                return "No hay información del pago para notificar.";
            }

            var status_HV = paymentResult_HV.IsSuccessful_HV ? "exitoso" : "rechazado";
            return $"Pago {status_HV} por {paymentResult_HV.Amount_HV:C2}. {paymentResult_HV.Message_HV}";
        }
    }
}
