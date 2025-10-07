using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.PaymentMethods
{
    /// <summary>
    /// Implementación de pago con tarjeta de crédito siguiendo OCP/LSP.
    /// </summary>
    public class CreditCardPaymentHV : IPaymentMethod
    {
        private const decimal MaxAmountAllowed_HV = 5000m;

        /// <summary>
        /// Nombre auto descriptivo expuesto a los clientes.
        /// </summary>
        public string PaymentMethodName => "Tarjeta de Crédito";

        /// <summary>
        /// Valida que el monto sea positivo y no supere el límite permitido.
        /// </summary>
        /// <param name="amount">Monto a procesar.</param>
        /// <returns>True si el monto es válido.</returns>
        public bool ValidateAmount(decimal amount)
        {
            return amount > 0 && amount <= MaxAmountAllowed_HV;
        }

        /// <summary>
        /// Procesa el pago simulando la autorización de la tarjeta.
        /// </summary>
        /// <param name="Amount">Monto a procesar.</param>
        /// <returns>Resultado del pago con mensaje y transacción.</returns>
        public PaymentResult_HV ProcessPayment_HV(decimal amount)
        {
            if (!ValidateAmount(amount))
            {
                return new PaymentResult_HV
                {
                    IsSuccessful = false,
                    Message = "Monto inválido para tarjeta de crédito.",
                    Amount = amount,
                    PaymentMethod = PaymentMethodName
                };
            }

            // Se simula la autorización del banco emisor.
            return new PaymentResult_HV
            {
                IsSuccessful = true,
                Message = "Pago autorizado por la tarjeta de crédito.",
                TransactionId = Guid.NewGuid().ToString("N"),
                Amount = amount,
                PaymentMethod = PaymentMethodName
            };
        }
    }
}
