using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts
{
    /// <summary>
    /// SRP: Interface solo para procesar pagos
    /// </summary>
    public interface IPaymentMethod_HV
    {
        /// <summary>
        /// Procesa el pago con el monto especificado
        /// </summary>
        PaymentResult_HV ProcessPayment_HV(decimal amount_HV);
        
        /// <summary>
        /// Nombre del método de pago
        /// </summary>
        string PaymentMethodName_HV { get; }
        
        /// <summary>
        /// Valida si puede procesar el monto
        /// </summary>
        bool ValidateAmount_HV(decimal amount_HV);
    }
}