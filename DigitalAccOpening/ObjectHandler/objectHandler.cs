using ACCOP.DLInterfaces;
using ACCOP.DL.SQLDatabase;
namespace DigitalAccOpening.ObjectHandler
{
    public class objectHandler
    {
        private static ICustomerStartingInfoDL StartingDL = new CustomerStartingInfoDB();


        public static ICustomerStartingInfoDL GetCustomerStartingInfoDL()
        {
            return StartingDL;
        }
    }
}
