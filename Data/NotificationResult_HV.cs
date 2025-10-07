namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data
{
    /// <summary>
    /// SRP: Solo encapsula resultados de notificación
    /// </summary>
    public class NotificationResult_HV
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string Channel { get; set; }
        public System.DateTime SentAt { get; set; }

        public NotificationResult_HV()
        {
            Message = string.Empty;
            Channel = string.Empty;
            SentAt = System.DateTime.Now;
        }
    }
}
