using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts
{
    /// <summary>
    /// ISP/DIP: Permite que el canal decida cómo obtener el contacto del destinatario.
    /// </summary>
    public interface IRecipientDestination_HV
    {
        string ExtractDestination_HV(RecipientInfo_HV recipient_HV);
    }
}
