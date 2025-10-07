using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Services
{
    /// <summary>
    /// SRP: Orquesta el procesamiento de pagos y el envío de notificaciones.
    /// DIP: Depende solo de interfaces para métodos de pago y notificación.
    /// </summary>
    public class PaymentProcessor_HV : IPaymentProcessor
    {
        private readonly IPaymentMethod[] _paymentMethods_HV;
        private readonly IPaymentNotificationService _notificationService_HV;

        public PaymentProcessor_HV(IPaymentMethod[] paymentMethods_HV, IPaymentNotificationService notificationService_HV)
        {
            _paymentMethods_HV = paymentMethods_HV ?? new IPaymentMethod[0];
            _notificationService_HV = notificationService_HV ?? throw new ArgumentNullException(nameof(notificationService_HV));
        }

        /// <summary>
        /// Ejecuta el pago seleccionado y notifica al usuario.
        /// </summary>
        public PaymentSummary_HV ProcessPayment_HV(PaymentRequest_HV request_HV)
        {
            if (request_HV == null)
            {
                throw new ArgumentNullException(nameof(request_HV));
            }

            var selectedMethod_HV = FindPaymentMethod(request_HV.PaymentMethodName);
            PaymentResult_HV paymentResult_HV;

            if (selectedMethod_HV == null)
            {
                paymentResult_HV = new PaymentResult_HV
                {
                    IsSuccessful = false,
                    Message = "Método de pago no encontrado.",
                    Amount = request_HV.Amount,
                    PaymentMethod = request_HV.PaymentMethodName
                };
            }
            else
            {
                paymentResult_HV = selectedMethod_HV.ProcessPayment_HV(request_HV.Amount);
            }

            var notificationResults_HV = _notificationService_HV.NotifyPaymentResult_HV(paymentResult_HV, request_HV.Recipient);

            return new PaymentSummary_HV
            {
                PaymentResult = paymentResult_HV,
                NotificationResults = notificationResults_HV
            };
        }

        private IPaymentMethod FindPaymentMethod(string methodName)
        {
            if (_paymentMethods_HV.Length == 0)
            {
                return null;
            }

            for (var index_HV = 0; index_HV < _paymentMethods_HV.Length; index_HV++)
            {
                var method_HV = _paymentMethods_HV[index_HV];
                if (method_HV != null && string.Equals(method_HV.PaymentMethodName, methodName, StringComparison.OrdinalIgnoreCase))
                {
                    return method_HV;
                }
            }

            return null;
        }
    }
}
