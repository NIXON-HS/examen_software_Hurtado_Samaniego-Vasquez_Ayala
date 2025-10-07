using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts
{
    /// <summary>
    /// ISP: Interface base solo con métodos esenciales de notificación
    /// </summary>
    public interface INotificationChannel
    {
        /// <summary>
        /// Envía notificación básica
        /// </summary>
        NotificationResult_HV SendNotification_HV(string message);

        /// <summary>
        /// Nombre del canal
        /// </summary>
        string ChannelName { get; }
    }
}
