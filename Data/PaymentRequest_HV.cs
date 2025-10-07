namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data
{
    /// <summary>
    /// SRP: Representa la solicitud de pago con monto, método y destinatario.
    /// </summary>
    public class PaymentRequest_HV
    {
        public decimal Amount { get; set; }
        public string PaymentMethodName { get; set; }
        public string Concept { get; set; }
        public RecipientInfo_HV Recipient { get; set; }

        public PaymentRequest_HV()
        {
            PaymentMethodName = string.Empty;
            Concept = string.Empty;
            Recipient = new RecipientInfo_HV();
        }
    }
}
