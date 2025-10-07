using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.PaymentMethods
{
    /// <summary>
    /// Implementación de pago en efectivo.
    /// </summary>
    public class CashPaymentHV : IPaymentMethod_HV
    {
        private const decimal MaxCashAmount_HV = 1000m;

        /// <summary>
        /// Nombre amigable para mostrar al usuario final.
        /// </summary>
        public string PaymentMethodName_HV => "Pago en Efectivo";

        /// <summary>
        /// El efectivo tiene un límite práctico para control de caja.
        /// </summary>
        /// <param name="amount_HV">Monto del pago.</param>
        /// <returns>True si el monto es aceptable.</returns>
        public bool ValidateAmount_HV(decimal amount_HV)
        {
            return amount_HV > 0 && amount_HV <= MaxCashAmount_HV;
        }

        /// <summary>
        /// Registra el pago en efectivo en la caja del negocio.
        /// </summary>
        /// <param name="amount_HV">Monto recibido.</param>
        /// <returns>Resultado con confirmación de caja.</returns>
        public PaymentResult_HV ProcessPayment_HV(decimal amount_HV)
        {
            if (!ValidateAmount_HV(amount_HV))
            {
                return new PaymentResult_HV
                {
                    IsSuccessful_HV = false,
                    Message_HV = "Monto no válido para pago en efectivo.",
                    Amount_HV = amount_HV,
                    PaymentMethod_HV = PaymentMethodName_HV
                };
            }

            return new PaymentResult_HV
            {
                IsSuccessful_HV = true,
                Message_HV = "Pago en efectivo registrado correctamente.",
                TransactionId_HV = $"CASH-{amount_HV:000000000}",
                Amount_HV = amount_HV,
                PaymentMethod_HV = PaymentMethodName_HV
            };
        }
    }
}
