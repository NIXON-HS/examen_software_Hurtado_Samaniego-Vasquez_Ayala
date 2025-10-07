using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.PaymentMethods
{
    /// <summary>
    /// Implementación de pago en efectivo.
    /// </summary>
    public class CashPaymentHV : IPaymentMethod
    {
        private const decimal MaxCashAmount = 5000m;

        /// <summary>
        /// Nombre amigable para mostrar al usuario final.
        /// </summary>
        public string PaymentMethodName => "Pago en Efectivo";

        /// <summary>
        /// El efectivo tiene un límite práctico para control de caja.
        /// </summary>
        /// <param name="Amount">Monto del pago.</param>
        /// <returns>True si el monto es aceptable.</returns>
        public bool ValidateAmount(decimal Amount)
        {
            return Amount > 0 && Amount <= MaxCashAmount;
        }

        /// <summary>
        /// Registra el pago en efectivo en la caja del negocio.
        /// </summary>
        /// <param name="Amount">Monto recibido.</param>
        /// <returns>Resultado con confirmación de caja.</returns>
        public PaymentResult_HV ProcessPayment_HV(decimal Amount)
        {
            if (!ValidateAmount(Amount))
            {
                return new PaymentResult_HV
                {
                    IsSuccessful = false,
                    Message = "Monto no válido para pago en efectivo.",
                    Amount = Amount,
                    PaymentMethod = PaymentMethodName
                };
            }

            return new PaymentResult_HV
            {
                IsSuccessful = true,
                Message = "Pago en efectivo registrado correctamente.",
                TransactionId = $"CASH-{Amount:000000000}",
                Amount = Amount,
                PaymentMethod = PaymentMethodName
            };
        }
    }
}
