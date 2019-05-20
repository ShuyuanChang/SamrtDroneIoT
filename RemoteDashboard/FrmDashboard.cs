using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Shared;
using Newtonsoft.Json;


namespace Rakutenwinapp
{
    public partial class FrmDashboard : Form
    {
        static RegistryManager registryManager;
        static string connectionString = "[Your IoT Hub Connection String]";
        private Twin drone;
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private async void GetStatus() {
            drone = await registryManager.GetTwinAsync(txtDeviceId.Text);

            if (drone == null)
            {
                comCommand.Enabled = false;
                btnSubmit.Enabled = false;
                lblStatus.Text = String.Empty;

                MessageBox.Show("Device Not Fund!");
            }
            else
            {
                comCommand.Enabled = true;
                btnSubmit.Enabled = true;

                var deviceTwin = JsonConvert.DeserializeObject<Dictionary<object, object>>(drone.ToJson());
                var properties = JsonConvert.DeserializeObject<Dictionary<object, object>>(deviceTwin["properties"].ToString());
                var desired = JsonConvert.DeserializeObject<Dictionary<object, object>>(properties["desired"].ToString());
                var reported = JsonConvert.DeserializeObject<Dictionary<object, object>>(properties["reported"].ToString());

                lblStatus.SuspendLayout();
                //lblStatus.Text = drone.ToJson();
                lblStatus.Text = "Desired Command:" + desired["command"].ToString();
                lblStatus.Text += "\r\nReported Command:" + reported["ReportedCommand"].ToString();
                lblStatus.Text += "\r\nLocation:" + reported["location"].ToString();
                lblStatus.Text += "\r\nBattery:" + reported["DroneBattery"].ToString();
                lblStatus.ResumeLayout();
            }

        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            GetStatus();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var patch = new
            {
                properties = new
                {
                    desired = new
                    {
                        command = comCommand.SelectedItem.ToString()
                    }
                }
            };
            await registryManager.UpdateTwinAsync(drone.DeviceId, JsonConvert.SerializeObject(patch), drone.ETag);

            drone = await registryManager.GetTwinAsync(txtDeviceId.Text);
            GetStatus();
        }
    }
}
