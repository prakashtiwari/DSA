using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessor
    {
        private IDeskBookingRepository _deskBookingRepository;
        private IDeskRepository _deskRepository;

        public DeskBookingRequestProcessor(IDeskBookingRepository deskBookingRepository, IDeskRepository deskRepository)
        {
            this._deskBookingRepository = deskBookingRepository;
            this._deskRepository = deskRepository;
        }

        public DeskBookingResult Book(DeskBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var availableDesk = _deskRepository.GetAvailableDesks();
            var result = Create<DeskBookingResult>(request);
           
            if (availableDesk.FirstOrDefault() is Desk desk)
            {
                //var desk = availableDesk.First();
                var bookedDesk = Create<DeskBooking>(request);
                bookedDesk.DeskId = desk.Id;
                _deskBookingRepository.Save(bookedDesk);
                result.DeskBookingId = desk.Id;
               result.Code = DeskBookingResultCode.Success;

            }
            else
            {
                result.Code = DeskBookingResultCode.NoDeskAvailable;

            }
            return result;
        }

        private static T Create<T>(DeskBookingRequest request) where T : DeskBookingBase, new()
        {
            return new T
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfB = request.DateOfB,
                Email = request.Email
            };
        }
    }
}