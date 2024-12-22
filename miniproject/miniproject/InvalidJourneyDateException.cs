using System;

namespace TrainReservationSystem.Services
{
    public class InvalidJourneyDateException : Exception
    {
        public InvalidJourneyDateException(string message) : base(message) { }
    }
}
