using System;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Shared;
using Microsoft.Azure.Devices.Client;
using TelloSharp;


namespace TelloNetCore
{
    class Program    
    {
        private static TransportType s_transportType = TransportType.Mqtt;
        private static string s_deviceConnectionString = "[Your Device Connection String]";

        private static TelloClient client;
        private static DeviceClient deviceClient;
        private static string twinjson = String.Empty;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello Smart Drone!");
            client = new TelloClient();
            deviceClient = DeviceClient.CreateFromConnectionString(s_deviceConnectionString, s_transportType);
            await deviceClient.SetDesiredPropertyUpdateCallbackAsync(OnDesiredPropertyChanged, null).ConfigureAwait(false);
            Console.ReadLine();
        }

        private static async Task OnDesiredPropertyChanged(TwinCollection desiredProperties, object userContext)
        {
            string desiredcommand = (string)desiredProperties["command"];
            Console.Write("\r\nDrone Control:\r\nNew desired command:" + desiredcommand);

            // Execute the command. Need to handle the exceptions.
            try
            {
                if (desiredcommand == "Takeoff")
                {
                    await client.TakeOff();

                }
                else
                {
                    await client.Land();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Drone Control Exception:\r\n" + e.ToString());
            }

            TwinCollection reportedProperties = new TwinCollection();
            reportedProperties["DateTimeLastDesiredPropertyChangeReceived"] = DateTime.Now;
            reportedProperties["ReportedCommand"] = desiredcommand;
            await deviceClient.UpdateReportedPropertiesAsync(reportedProperties).ConfigureAwait(false);

            Twin twin = await deviceClient.GetTwinAsync().ConfigureAwait(false);
            twinjson = twin.ToJson();


        }
    }
}
