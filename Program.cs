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
        // DIP: Configuración de dependencias mediante inyección por constructor
        IPaymentMethod[] paymentMethods_HV = new IPaymentMethod[]
        {
            new CreditCardPaymentHV(),
            new BankTransferPaymentHV(),
            new CashPaymentHV()
        };

        INotificationChannel[] notificationChannels_HV = new INotificationChannel[]
        {
            new EmailNotificationChannelHV(),
            new SmsNotificationChannelHV(),
            new WhatsAppNotificationChannelHV()
        };

        IPaymentNotificationService notificationService_HV = new PaymentNotificationService_HV(notificationChannels_HV);
        IPaymentProcessor paymentProcessor_HV = new PaymentProcessor_HV(paymentMethods_HV, notificationService_HV);

        // Datos precargados respetando la restricción de evitar genéricos
        PaymentRequest_HV[] requests_HV = new PaymentRequest_HV[]
        {
            new PaymentRequest_HV
            {
                Amount = 320.50m,
                Concept = "Pago Matricula",
                PaymentMethodName = "Tarjeta de Crédito",
                Recipient = new RecipientInfo_HV
                {
                    Name = "Andrea Vasquez",
                    Email = "andrea.vasquez@gmail.com",
                    PhoneNumber = "0992730001",
                    WhatsappNumber = "0992730001"
                }
            },
            new PaymentRequest_HV
            {
                Amount = 8m,
                Concept = "Pago de Casa",
                PaymentMethodName = "Transferencia Bancaria",
                Recipient = new RecipientInfo_HV
                {
                    Name = "Maybelline Navarro",
                    Email = "maybelline.navarro@yahoo.com",
                    PhoneNumber = "0987654321",
                    WhatsappNumber = "0987654321"
                }
            },
            new PaymentRequest_HV
            {
                Amount = 1500m,
                Concept = "Compra de Laptop",
                PaymentMethodName = "Pago en Efectivo",
                Recipient = new RecipientInfo_HV
                {
                    Name = "Juanito Alimaña",
                    Email = "juanito.alimania@hotmail.com",
                    PhoneNumber = "09876789876",
                    WhatsappNumber = "0992730001"
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
    /// SRP: Método con una sola responsabilidad - mostrar resumen en consola
    /// </summary>
    private static void PrintSummary_HV(PaymentRequest_HV request_HV, PaymentSummary_HV summary_HV)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Método solicitado: " + request_HV.PaymentMethodName);
        Console.WriteLine("Resultado: " + (summary_HV.PaymentResult.IsSuccessful ? "Éxito" : "Fallo"));
        Console.WriteLine("Detalle: " + summary_HV.PaymentResult.Message);
        Console.WriteLine("Transacción: " + summary_HV.PaymentResult.TransactionId);

        if (summary_HV.NotificationResults != null)
        {
            for (var index_HV = 0; index_HV < summary_HV.NotificationResults.Length; index_HV++)
            {
                var notification_HV = summary_HV.NotificationResults[index_HV];
                if (notification_HV == null)
                {
                    continue;
                }

                Console.WriteLine(" - Notificación " + notification_HV.Channel + ": " + (notification_HV.IsSuccessful ? "Enviada" : "Falló") + " | " + notification_HV.Message);
            }
        }

        Console.WriteLine("========================================\n");
    }
}
