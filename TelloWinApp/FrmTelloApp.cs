using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TelloSharp;
using Microsoft.Azure.Devices.Shared;
using Microsoft.Azure.Devices.Client;

namespace tellowinapp
{
    public partial class Form1 : Form
    {
        // Select one of the following transports used by DeviceClient to connect to IoT Hub.
        //private TransportType s_transportType = TransportType.Amqp;
        private TransportType s_transportType = TransportType.Mqtt;
        //private TransportType s_transportType = TransportType.Http1;
        //private TransportType s_transportType = TransportType.Amqp_WebSocket_Only;
        //private TransportType s_transportType = TransportType.Mqtt_WebSocket_Only;

        private static string s_deviceConnectionString = "[Your Device Connection String]";

        private TelloClient client;
        private DeviceClient deviceClient;
        private string twinjson = String.Empty;

        public Form1()
        {
            InitializeComponent();
            
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            string data = "Test mode.";

            await client.TakeOff();
            data = client.GetBatteryLevel().Result.ToString();

            lblStatus.SuspendLayout();
            lblStatus.Text = "Battery:" + data;
            // + "/" + client.GetFlightTime().Result.ToString();
            lblStatus.ResumeLayout();
            timer1.Enabled = true;
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            await client.Land();
            timer1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var data  = client.GetFlightTime();
            //label1.Text = data.Result.ToString();
            //timer1.Start();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            SetText("");
            client = new TelloClient();
            deviceClient = DeviceClient.CreateFromConnectionString(s_deviceConnectionString, s_transportType);
            await deviceClient.SetDesiredPropertyUpdateCallbackAsync(OnDesiredPropertyChanged, null).ConfigureAwait(false);

            TwinCollection reportedProperties = new TwinCollection();
            reportedProperties["DateTimeLastDesiredPropertyChangeReceived"] = DateTime.Now;
            reportedProperties["location"] = "{0,0}";
            await deviceClient.UpdateReportedPropertiesAsync(reportedProperties).ConfigureAwait(false);

            if (deviceClient == null)
            {
                SetText("Failed to create DeviceClient!");
            }
            else
            {
                timer1.Enabled = true;
                Twin twin = await deviceClient.GetTwinAsync().ConfigureAwait(false);
                twinjson = twin.ToJson();
                
            }


            MessageBox.Show("Drone Control:\r\nDevice client is ready!");
            SetText("Drone Control:\r\nDevice client is ready!");

        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblStatus.Text += "\r\n" + text;
            }
        }

        /// <summary>
        /// Update drone status to device twins.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private int batterylevel = 100;
        private async void timer1_Tick(object sender, EventArgs e)
        {
            TwinCollection reportedProperties = new TwinCollection();
            reportedProperties["DateTimeLastDroneUpdate"] = DateTime.Now;
            reportedProperties["DroneBattery"] = batterylevel;
            //lblStatus.SuspendLayout();
            //lblStatus.Text = "Battery level:" + batterylevel;
            //lblStatus.ResumeLayout();

            //Test
            if (batterylevel >= 0) {
                batterylevel--;
            }

            await deviceClient.UpdateReportedPropertiesAsync(reportedProperties).ConfigureAwait(false);
        }

        private async Task OnDesiredPropertyChanged(TwinCollection desiredProperties, object userContext)
        {
            string desiredcommand = (string) desiredProperties["command"];
            //MessageBox.Show("Drone Control:\r\nNew desired command:" + desiredcommand);
            SetText("\r\nDrone Control:\r\nNew desired command:" + desiredcommand);

            // Execute the command. Need to handle the exceptions.
            try
            {
                if (desiredcommand == "Takeoff")
                {
                    await client.TakeOff();

                }
                else{
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

        private async void btnUp_Click(object sender, EventArgs e)
        {
            await client.Fly(FlyDirection.Foward, 20);

            TwinCollection reportedProperties = new TwinCollection();
            reportedProperties["DateTimeLastDesiredPropertyChangeReceived"] = DateTime.Now;
            reportedProperties["location"] = "{20,0}";
            await deviceClient.UpdateReportedPropertiesAsync(reportedProperties).ConfigureAwait(false);
            Twin twin = await deviceClient.GetTwinAsync().ConfigureAwait(false);
            SetText("\r\nDevice Control:\r\nNew Location:{20:0}");
        }
    }
}
