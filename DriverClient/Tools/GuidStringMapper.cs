using System;

namespace DriverClient.Tools
{
    public class GuidStringMapper
    {
        public Guid Id { get; set; }
        public string StringGuid
        {
            get => Id == Guid.Empty ? string.Empty : Id.ToString();
            set => Id = System.Guid.Parse(value);
        }
    }
}