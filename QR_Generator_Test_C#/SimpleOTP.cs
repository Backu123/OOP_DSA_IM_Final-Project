using System;
using System.Windows.Forms;

namespace QR_Generator_Test_C_
{
    internal class SimpleOTP
    {
        private OTPBase otp;

        public string Generate()
        {   
            // POLYMORPHISM
            otp = new NumericOTP();
            // otp = new AlphaNumericOTP();

            return otp.GenerateOTP();
        }

        public bool Validate(string input)
        {
            if (otp == null)
                return false;

            return otp.ValidateOTP(input);
        }
    }

    // OOP CLASS

    // ABSTRACTION
    abstract class OTPBase
    {
        protected string currentOTP;

        public abstract string GenerateOTP();

        public virtual bool ValidateOTP(string input)
        {
            return currentOTP == input;
        }
    }

    // INHERITANCE
    class NumericOTP : OTPBase
    {
        public override string GenerateOTP()
        {
            Random rnd = new Random();
            currentOTP = rnd.Next(100000, 999999).ToString();
            return currentOTP;
        }
    }

    // OPTIONAL (POLYMORPHISM DEMO)
    class AlphaNumericOTP : OTPBase
    {
        public override string GenerateOTP()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            currentOTP = "";

            for (int i = 0; i < 6; i++)
                currentOTP += chars[rnd.Next(chars.Length)];

            return currentOTP;
        }
    }
}
