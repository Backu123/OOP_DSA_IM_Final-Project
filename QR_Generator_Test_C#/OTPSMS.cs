using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace QR_Generator_Test_C_
{
    class OTPSMS
    {
        private readonly string accountSid = "YOUR_TWILIO_ACCOUNT_SID";
        private readonly string authToken = "YOUR_TWILIO_AUTH_TOKEN";
        private readonly string fromPhone = "+1XXXXXXXXXX"; // Twilio number

        public bool SendOTP(string otpCode, string toPhone)
        {
            try
            {
                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: $"Your OTP code is: {otpCode}",
                    from: new PhoneNumber(fromPhone),
                    to: new PhoneNumber(toPhone)
                );

                return message.Sid != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
