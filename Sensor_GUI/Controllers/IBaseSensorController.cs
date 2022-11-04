namespace Sensor_GUI.Controllers
{
    internal interface IBaseSensorController
    {
        public bool Connect();
        public void Disconnect();
        public bool SetConnectionString(string connectionString);

    }
}
