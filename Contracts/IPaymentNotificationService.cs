using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts
{
    /// <summary>
    /// DIP: Define cómo se envían las notificaciones posteriores al pago.
    /// </summary>
    public interface IPaymentNotificationService
    {
        NotificationResult_HV[] NotifyPaymentResult_HV(PaymentResult_HV paymentResult_HV, RecipientInfo_HV Recipient);
    }
}
