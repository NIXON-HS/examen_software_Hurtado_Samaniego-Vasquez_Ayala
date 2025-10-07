namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data
{
    /// <summary>
    /// SRP: Solo encapsula resultados de pago
    /// </summary>
    public class PaymentResult_HV
    {
        public bool IsSuccessful_HV { get; set; }
        public string Message_HV { get; set; }
        public string TransactionId_HV { get; set; }
        public decimal Amount_HV { get; set; }
        public string PaymentMethod_HV { get; set; }

        public PaymentResult_HV()
        {
            Message_HV = string.Empty;
            TransactionId_HV = string.Empty;
            PaymentMethod_HV = string.Empty;
        }
    }
}