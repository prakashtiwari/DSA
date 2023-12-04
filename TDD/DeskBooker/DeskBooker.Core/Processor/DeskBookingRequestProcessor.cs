using DeskBooker.Core.Domain;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessor
    {
        public DeskBookingRequestProcessor()
        {
        }

        public DeskBookingResult Book(DeskBookingRequest request)
        {
            if (request == null)
            { 
             throw new ArgumentNullException(nameof(request));
            }
            return new DeskBookingResult
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfB=request.DateOfB,
                Email=request.Email
            };
        }
    }
}