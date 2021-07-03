namespace API.Extensions
{
    public static class NetPayExtension
    {
        public static int CalculateNetPay(int tuition, int averageAid)
        {
            var netPay = tuition - averageAid;

            return netPay;
        }
    }
}