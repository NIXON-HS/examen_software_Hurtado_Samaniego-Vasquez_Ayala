using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Services
{
    /// <summary>
    /// SRP: Orquesta el procesamiento de pagos y el envío de notificaciones.
    /// DIP: Depende solo de interfaces para métodos de pago y notificación.
    /// </summary>
    public class PaymentProcessor_HV : IPaymentProcessor_HV
    {
        private readonly IPaymentMethod_HV[] _paymentMethods_HV;
        private readonly IPaymentNotificationService_HV _notificationService_HV;

        public PaymentProcessor_HV(IPaymentMethod_HV[] paymentMethods_HV, IPaymentNotificationService_HV notificationService_HV)
        {
            _paymentMethods_HV = paymentMethods_HV ?? new IPaymentMethod_HV[0];
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

            var selectedMethod_HV = FindPaymentMethod_HV(request_HV.PaymentMethodName_HV);
            PaymentResult_HV paymentResult_HV;

            if (selectedMethod_HV == null)
            {
                paymentResult_HV = new PaymentResult_HV
                {
                    IsSuccessful_HV = false,
                    Message_HV = "Método de pago no encontrado.",
                    Amount_HV = request_HV.Amount_HV,
                    PaymentMethod_HV = request_HV.PaymentMethodName_HV
                };
            }
            else
            {
                paymentResult_HV = selectedMethod_HV.ProcessPayment_HV(request_HV.Amount_HV);
            }

            var notificationResults_HV = _notificationService_HV.NotifyPaymentResult_HV(paymentResult_HV, request_HV.Recipient_HV);

            return new PaymentSummary_HV
            {
                PaymentResult_HV = paymentResult_HV,
                NotificationResults_HV = notificationResults_HV
            };
        }

        private IPaymentMethod_HV FindPaymentMethod_HV(string methodName_HV)
        {
            if (_paymentMethods_HV.Length == 0)
            {
                return null;
            }

            for (var index_HV = 0; index_HV < _paymentMethods_HV.Length; index_HV++)
            {
                var method_HV = _paymentMethods_HV[index_HV];
                if (method_HV != null && string.Equals(method_HV.PaymentMethodName_HV, methodName_HV, StringComparison.OrdinalIgnoreCase))
                {
                    return method_HV;
                }
            }

            return null;
        }
    }
}
