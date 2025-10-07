using System;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Contracts;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Data;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.NotificationChannels;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.PaymentMethods;
using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Services;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala;

internal static class Program
{
    static void Main(string[] args)
    {
        // Configuración de dependencias aplicando DIP mediante inyección por constructor.
        IPaymentMethod_HV[] paymentMethods_HV = new IPaymentMethod_HV[]
        {
            new CreditCardPaymentHV(),
            new BankTransferPaymentHV(),
            new CashPaymentHV()
        };

        INotificationChannel_HV[] notificationChannels_HV = new INotificationChannel_HV[]
        {
            new EmailNotificationChannelHV(),
            new SmsNotificationChannelHV(),
            new WhatsAppNotificationChannelHV()
        };

        IPaymentNotificationService_HV notificationService_HV = new PaymentNotificationService_HV(notificationChannels_HV);
        IPaymentProcessor_HV paymentProcessor_HV = new PaymentProcessor_HV(paymentMethods_HV, notificationService_HV);

        // Datos precargados respetando la restricción de evitar colecciones genéricas.
        PaymentRequest_HV[] requests_HV = new PaymentRequest_HV[]
        {
            new PaymentRequest_HV
            {
                Amount_HV = 320.50m,
                Concept_HV = "Pago Matricula",
                PaymentMethodName_HV = "Tarjeta de Crédito",
                Recipient_HV = new RecipientInfo_HV
                {
                    Name_HV = "Andrea Vasquez",
                    Email_HV = "andrea.vasquez@gmail.com",
                    PhoneNumber_HV = "0992730001",
                    WhatsappNumber_HV = "0992730001"
                }
            },
            new PaymentRequest_HV
            {
                Amount_HV = 8m,
                Concept_HV = "Pago de Casa",
                PaymentMethodName_HV = "Transferencia Bancaria",
                Recipient_HV = new RecipientInfo_HV
                {
                    Name_HV = "Maybelline Navarro",
                    Email_HV = "maybelline.navarro@yahoo.com",
                    PhoneNumber_HV = "0987654321",
                    WhatsappNumber_HV = "0987654321"
                }
            },
            new PaymentRequest_HV
            {
                Amount_HV = 1500m,
                Concept_HV = "Compra de Laptop",
                PaymentMethodName_HV = "Pago en Efectivo",
                Recipient_HV = new RecipientInfo_HV
                {
                    Name_HV = "Juanito Alimaña",
                    Email_HV = "juanito.alimania@hotmail.com",
                    PhoneNumber_HV = "09876789876",
                    WhatsappNumber_HV = "0992730001"
                }
            }
        };

        for (var index_HV = 0; index_HV < requests_HV.Length; index_HV++)
        {
            var request_HV = requests_HV[index_HV];
            var summary_HV = paymentProcessor_HV.ProcessPayment_HV(request_HV);
            PrintSummary_HV(request_HV, summary_HV);
        }
    }

    /// <summary>
    /// Presenta en consola el resultado del pago y las notificaciones asociadas.
    /// </summary>
    private static void PrintSummary_HV(PaymentRequest_HV request_HV, PaymentSummary_HV summary_HV)
    {
        Console.WriteLine("========================================");
        //Console.WriteLine("Pago para: " + request_HV.Recipient_HV.Name_HV);
        //Console.WriteLine("Concepto: " + request_HV.Concept_HV);
        //Console.WriteLine("Monto: " + request_HV.Amount_HV.ToString("C2"));
        Console.WriteLine("Método solicitado: " + request_HV.PaymentMethodName_HV);
        Console.WriteLine("Resultado: " + (summary_HV.PaymentResult_HV.IsSuccessful_HV ? "Éxito" : "Fallo"));
        Console.WriteLine("Detalle: " + summary_HV.PaymentResult_HV.Message_HV);
        Console.WriteLine("Transacción: " + summary_HV.PaymentResult_HV.TransactionId_HV);

        if (summary_HV.NotificationResults_HV != null)
        {
            for (var index_HV = 0; index_HV < summary_HV.NotificationResults_HV.Length; index_HV++)
            {
                var notification_HV = summary_HV.NotificationResults_HV[index_HV];
                if (notification_HV == null)
                {
                    continue;
                }

                Console.WriteLine(" - Notificación " + notification_HV.Channel_HV + ": " + (notification_HV.IsSuccessful_HV ? "Enviada" : "Falló") + " | " + notification_HV.Message_HV);
            }
        }

        Console.WriteLine("========================================\n");
    }
}