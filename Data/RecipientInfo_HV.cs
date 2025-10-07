namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data
{
    /// <summary>
    /// SRP: Agrupa los datos de contacto de un usuario para notificaciones.
    /// </summary>
    public class RecipientInfo_HV
    {
        public string Name_HV { get; set; }
        public string Email_HV { get; set; }
        public string PhoneNumber_HV { get; set; }
        public string WhatsappNumber_HV { get; set; }

        public RecipientInfo_HV()
        {
            Name_HV = string.Empty;
            Email_HV = string.Empty;
            PhoneNumber_HV = string.Empty;
            WhatsappNumber_HV = string.Empty;
        }
    }
}
