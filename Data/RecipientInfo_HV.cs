namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data
{
    /// <summary>
    /// SRP: Agrupa los datos de contacto de un usuario para notificaciones.
    /// </summary>
    public class RecipientInfo_HV
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsappNumber { get; set; }

        public RecipientInfo_HV()
        {
            Name = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            WhatsappNumber = string.Empty;
        }
    }
}
