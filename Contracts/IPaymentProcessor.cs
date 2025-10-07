using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts
{
    /// <summary>
    /// DIP: Abstracción para procesadores de pago extensibles.
    /// </summary>
    public interface IPaymentProcessor
    {
        PaymentSummary_HV ProcessPayment_HV(PaymentRequest_HV request_HV);
    }
}
