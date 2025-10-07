using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.PaymentMethods
{
    /// <summary>
    /// Implementación de pago con tarjeta de crédito siguiendo OCP/LSP.
    /// </summary>
    public class CreditCardPaymentHV : IPaymentMethod_HV
    {
        private const decimal MaxAmountAllowed_HV = 5000m;

        /// <summary>
        /// Nombre auto descriptivo expuesto a los clientes.
        /// </summary>
        public string PaymentMethodName_HV => "Tarjeta de Crédito";

        /// <summary>
        /// Valida que el monto sea positivo y no supere el límite permitido.
        /// </summary>
        /// <param name="amount_HV">Monto a procesar.</param>
        /// <returns>True si el monto es válido.</returns>
        public bool ValidateAmount_HV(decimal amount_HV)
        {
            return amount_HV > 0 && amount_HV <= MaxAmountAllowed_HV;
        }

        /// <summary>
        /// Procesa el pago simulando la autorización de la tarjeta.
        /// </summary>
        /// <param name="amount_HV">Monto a procesar.</param>
        /// <returns>Resultado del pago con mensaje y transacción.</returns>
        public PaymentResult_HV ProcessPayment_HV(decimal amount_HV)
        {
            if (!ValidateAmount_HV(amount_HV))
            {
                return new PaymentResult_HV
                {
                    IsSuccessful_HV = false,
                    Message_HV = "Monto inválido para tarjeta de crédito.",
                    Amount_HV = amount_HV,
                    PaymentMethod_HV = PaymentMethodName_HV
                };
            }

            // Se simula la autorización del banco emisor.
            return new PaymentResult_HV
            {
                IsSuccessful_HV = true,
                Message_HV = "Pago autorizado por la tarjeta de crédito.",
                TransactionId_HV = Guid.NewGuid().ToString("N"),
                Amount_HV = amount_HV,
                PaymentMethod_HV = PaymentMethodName_HV
            };
        }
    }
}
