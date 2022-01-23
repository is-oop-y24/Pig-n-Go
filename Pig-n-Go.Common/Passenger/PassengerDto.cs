using System;
using Pig_n_Go.Core.Passenger;

namespace Pig_n_Go.Common.Passenger
{
    public class PassengerDto
    {
        public Guid Id { get; set; }
        public PassengerInfo PassengerInfo { get; set; }
    }
}