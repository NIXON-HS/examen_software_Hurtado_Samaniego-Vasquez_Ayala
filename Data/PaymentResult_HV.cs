namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data
{
    /// <summary>
    /// SRP: Solo encapsula resultados de pago
    /// </summary>
    public class PaymentResult_HV
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }

        public PaymentResult_HV()
        {
            Message = string.Empty;
            TransactionId = string.Empty;
            PaymentMethod = string.Empty;
        }
    }
}
