using examen_software_Hurtado_Samaniego_Vasquez_Ayala.Models;

namespace examen_software_Hurtado_Samaniego_Vasquez_Ayala.Interfaces;

public interface IPaymentMethodHSVA
{
    string MethodKey { get; }

    PaymentExecutionResultHSVA Process(PaymentRequestHSVA request);
}
