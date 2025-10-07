namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data
{
    /// <summary>
    /// SRP: Solo encapsula resultados de notificación
    /// </summary>
    public class NotificationResult_HV
    {
        public bool IsSuccessful_HV { get; set; }
        public string Message_HV { get; set; }
        public string Channel_HV { get; set; }
        public System.DateTime SentAt_HV { get; set; }

        public NotificationResult_HV()
        {
            Message_HV = string.Empty;
            Channel_HV = string.Empty;
            SentAt_HV = System.DateTime.Now;
        }
    }
}