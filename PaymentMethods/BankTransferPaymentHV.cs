using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.PaymentMethods
{
    /// <summary>
    /// Implementación de pago por transferencia bancaria.
    /// </summary>
    public class BankTransferPaymentHV : IPaymentMethod_HV
    {
        private const decimal MinimumAmount_HV = 10m;

        /// <summary>
        /// Etiqueta utilizada por los clientes al elegir el método.
        /// </summary>
        public string PaymentMethodName_HV => "Transferencia Bancaria";

        /// <summary>
        /// Las transferencias requieren un monto mínimo para cubrir comisiones.
        /// </summary>
        /// <param name="amount_HV">Monto a validar.</param>
        /// <returns>True si el monto cumple con el mínimo.</returns>
        public bool ValidateAmount_HV(decimal amount_HV)
        {
            return amount_HV >= MinimumAmount_HV;
        }

        /// <summary>
        /// Emula el registro de la transferencia y devuelve un identificador único.
        /// </summary>
        /// <param name="amount_HV">Monto a transferir.</param>
        /// <returns>Resultado con estado y referencia bancaria.</returns>
        public PaymentResult_HV ProcessPayment_HV(decimal amount_HV)
        {
            if (!ValidateAmount_HV(amount_HV))
            {
                return new PaymentResult_HV
                {
                    IsSuccessful_HV = false,
                    Message_HV = "El monto no alcanza el mínimo para transferencia.",
                    Amount_HV = amount_HV,
                    PaymentMethod_HV = PaymentMethodName_HV
                };
            }

            // Simula interacción con el core bancario.
            return new PaymentResult_HV
            {
                IsSuccessful_HV = true,
                Message_HV = "Transferencia registrada exitosamente.",
                TransactionId_HV = $"TRF-{Guid.NewGuid():N}",
                Amount_HV = amount_HV,
                PaymentMethod_HV = PaymentMethodName_HV
            };
        }
    }
}
