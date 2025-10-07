namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data
{
    /// <summary>
    /// SRP: Agrupa el resultado del pago y las notificaciones enviadas.
    /// </summary>
    public class PaymentSummary_HV
    {
        public PaymentResult_HV PaymentResult { get; set; }
        public NotificationResult_HV[] NotificationResults { get; set; }

        public PaymentSummary_HV()
        {
            PaymentResult = new PaymentResult_HV();
            NotificationResults = new NotificationResult_HV[0];
        }
    }
}
