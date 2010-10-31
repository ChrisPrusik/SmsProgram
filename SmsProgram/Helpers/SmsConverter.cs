using System;
using System.Collections.Generic;
using System.Text;

namespace SmsProgram
{
    public static class SmsConverter
    {
        public static string ToString(DeliveryTypes type)
        {
            try
            {
                return type.ToString().ToLower();
            }
            catch 
            {
                throw new Exception(String.Format(Messages.ErrorUnknownDeliveryType, type.ToString()));
            }
        }

        public static DeliveryTypes ToDeliveryTypes(string type)
        {
            try
            {
                return (DeliveryTypes)Enum.Parse(typeof(DeliveryTypes), type, true);
            }
            catch 
            {
                throw new Exception(String.Format(Messages.ErrorUnknownDeliveryType, type));
            }
        }

        public static string ToString(DeliveryProviders provider)
        {
            try
            {
                return provider.ToString();
            }
            catch
            {
                throw new Exception(String.Format(Messages.ErrorUnknownDeliveryProvider, provider));
            }
        }

        public static DeliveryProviders ToDeliveryProviders(string provider)
        {
            try
            {
                return (DeliveryProviders)Enum.Parse(typeof(DeliveryProviders), provider, true);
            }
            catch
            {
                throw new Exception(String.Format(Messages.ErrorUnknownDeliveryProvider, provider));
            }
        }
    }
}
