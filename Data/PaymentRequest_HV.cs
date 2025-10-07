namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data
{
    /// <summary>
    /// SRP: Representa la solicitud de pago con monto, método y destinatario.
    /// </summary>
    public class PaymentRequest_HV
    {
        public decimal Amount_HV { get; set; }
        public string PaymentMethodName_HV { get; set; }
        public string Concept_HV { get; set; }
        public RecipientInfo_HV Recipient_HV { get; set; }

        public PaymentRequest_HV()
        {
            PaymentMethodName_HV = string.Empty;
            Concept_HV = string.Empty;
            Recipient_HV = new RecipientInfo_HV();
        }
    }
}
