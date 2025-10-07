using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.PaymentMethods
{
    /// <summary>
    /// Implementación de pago por transferencia bancaria.
    /// </summary>
    public class BankTransferPaymentHV : IPaymentMethod
    {
        private const decimal MinimumAmount = 1m;

        /// <summary>
        /// Etiqueta utilizada por los clientes al elegir el método.
        /// </summary>
        public string PaymentMethodName => "Transferencia Bancaria";

        /// <summary>
        /// Las transferencias requieren un monto mínimo para cubrir comisiones.
        /// </summary>
        /// <param name="Amount">Monto a validar.</param>
        /// <returns>True si el monto cumple con el mínimo.</returns>
        public bool ValidateAmount(decimal Amount)
        {
            return Amount >= MinimumAmount;
        }

        /// <summary>
        /// Emula el registro de la transferencia y devuelve un identificador único.
        /// </summary>
        /// <param name="Amount">Monto a transferir.</param>
        /// <returns>Resultado con estado y referencia bancaria.</returns>
        public PaymentResult_HV ProcessPayment_HV(decimal Amount)
        {
            if (!ValidateAmount(Amount))
            {
                return new PaymentResult_HV
                {
                    IsSuccessful = false,
                    Message = "El monto no alcanza el mínimo para transferencia.",
                    Amount = Amount,
                    PaymentMethod = PaymentMethodName
                };
            }

            // Simula interacción con el core bancario.
            return new PaymentResult_HV
            {
                IsSuccessful = true,
                Message = "Transferencia registrada exitosamente.",
                TransactionId = $"TRF-{Guid.NewGuid():N}",
                Amount = Amount,
                PaymentMethod = PaymentMethodName
            };
        }
    }
}
