using System;
using Pig_n_Go.Core.Passenger;

namespace Pig_n_Go.Common.DTO.Passenger
{
    public class PassengerDTO
    {
        public Guid Id { get; set; }
        public PassengerInfo PassengerInfo { get; set; }
    }
}