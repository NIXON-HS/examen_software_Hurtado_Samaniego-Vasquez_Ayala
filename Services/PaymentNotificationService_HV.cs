using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Services
{
    /// <summary>
    /// SRP: Coordina el envío de notificaciones tras un pago.
    /// DIP: Depende de interfaces de canales de notificación.
    /// </summary>
    public class PaymentNotificationService_HV : IPaymentNotificationService
    {
        private readonly INotificationChannel[] _channels_HV;

        public PaymentNotificationService_HV(INotificationChannel[] channels_HV)
        {
            _channels_HV = channels_HV ?? new INotificationChannel[0];
        }

        /// <summary>
        /// Envía el resultado usando todos los canales disponibles.
        /// </summary>
        public NotificationResult_HV[] NotifyPaymentResult_HV(PaymentResult_HV paymentResult_HV, RecipientInfo_HV Recipient)
        {
            var channelsLength_HV = _channels_HV.Length;
            var results_HV = new NotificationResult_HV[channelsLength_HV];

            for (var index_HV = 0; index_HV < channelsLength_HV; index_HV++)
            {
                var channel_HV = _channels_HV[index_HV];
                var message_HV = BuildMessage_HV(paymentResult_HV);

                if (channel_HV is IRecipientNotification recipientChannel && channel_HV is IRecipientDestination destinationResolver_HV)
                {
                    var destination_HV = destinationResolver_HV.ExtractDestination_HV(Recipient);

                    if (string.IsNullOrWhiteSpace(destination_HV))
                    {
                        results_HV[index_HV] = new NotificationResult_HV
                        {
                            IsSuccessful = false,
                            Message = "No se encontró un contacto válido para este canal.",
                            Channel = channel_HV.ChannelName,
                            SentAt = DateTime.Now
                        };
                        continue;
                    }

                    results_HV[index_HV] = recipientChannel.SendToRecipient_HV(message_HV, destination_HV);
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

            var status_HV = paymentResult_HV.IsSuccessful ? "exitoso" : "rechazado";
            return $"Pago {status_HV} por {paymentResult_HV.Amount:C2}. {paymentResult_HV.Message}";
        }
    }
}
