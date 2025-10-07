namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data
{
    /// <summary>
    /// SRP: Agrupa el resultado del pago y las notificaciones enviadas.
    /// </summary>
    public class PaymentSummary_HV
    {
        public PaymentResult_HV PaymentResult_HV { get; set; }
        public NotificationResult_HV[] NotificationResults_HV { get; set; }

        public PaymentSummary_HV()
        {
            PaymentResult_HV = new PaymentResult_HV();
            NotificationResults_HV = new NotificationResult_HV[0];
        }
    }
}
