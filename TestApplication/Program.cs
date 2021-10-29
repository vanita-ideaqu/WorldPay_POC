using System;
using GP.WorldpayGateway;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Token creation without payment request
            string token = string.Empty;

            PaymentService tokenService = WorldpayAPIServices.SubmitTokenRequest();
            token = tokenService.Reply.Token.TokenDetails.PaymentTokenID;
            Console.WriteLine("Token:" + token);

            // Token creation with payment request
            //PaymentService orderService = WorldpayAPIServices.SubmitOrderRequest();
            //token = tokenService.Reply.OrderStatus.Token.TokenDetails.PaymentTokenID;
            //Console.WriteLine("Token:" + token);

            //string status = tokenService.Reply.OrderStatus.Payment.LastEvent;//AUTHORISED/REFUSED/ERROR
            //string authorisationId = tokenService.Reply.OrderStatus.Payment.AuthorisationId.Id;
            //Console.WriteLine("Authorisation Id: " + authorisationId);

        }
    }
}
