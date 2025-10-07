using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts
{
    /// <summary>
    /// ISP: Interface segregada para notificaciones con destinatario específico
    /// </summary>
    public interface IRecipientNotification_HV
    {
        /// <summary>
        /// Envía a destinatario específico
        /// </summary>
        NotificationResult_HV SendToRecipient_HV(string message_HV, string recipient_HV);
    }
}