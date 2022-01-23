using System;

namespace DriverClient.Tools
{
    public class DriverGuid
    {
        public Guid Guid { get; set; }
        public string StringGuid
        {
            get => Guid == Guid.Empty ? string.Empty : Guid.ToString();
            set => Guid = System.Guid.Parse(value);
        }
    }
}