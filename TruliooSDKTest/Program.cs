using System;
using TruliooSDK;

namespace TruliooSDKTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var truliooClient = new TruliooSDK.TruliooSDKClient(Mode.Trial, "b1c62d1ce28dc4bc30538fc3967bfac0");
            var connection = truliooClient.Connection.GetTestAuthentication();
            Console.ReadLine();

        }
    }
}
