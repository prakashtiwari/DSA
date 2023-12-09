using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using Moq;
using Xunit.Sdk;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTest
    {
        public DeskBookingRequestProcessor processor;
        private readonly DeskBookingRequest _request;
        private readonly List<Desk> _availableDesks;
        private readonly Mock<IDeskBookingRepository> _deskBookingRepositoryMock;
        private readonly Mock<IDeskRepository> _deskRepositoryMock;

        public DeskBookingRequestProcessorTest()
        {
            _request = new DeskBookingRequest()
            {
                FirstName = "Prakash",
                LastName = "Tiwari",
                Email = "p@t.com",
                DateOfB = new DateTime(1986, 1, 22)

            };
            _availableDesks = new List<Desk> { new Desk { Id = 5 } };
            _deskBookingRepositoryMock = new Mock<IDeskBookingRepository>();
            _deskRepositoryMock = new Mock<IDeskRepository>();
            _deskRepositoryMock.Setup(p => p.GetAvailableDesks()).Returns(_availableDesks);
            processor = new DeskBookingRequestProcessor(_deskBookingRepositoryMock.Object, _deskRepositoryMock.Object);



        }

        [Fact]
        public void ShouldReturnDeskBookingResultWithValues()
        {
            //Arrange        
            //Act
            DeskBookingResult result = processor.Book(_request);
            Assert.NotNull(result);
            Assert.Equal(_request.FirstName, result.FirstName);
            Assert.Equal(_request.LastName, result.LastName);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.DateOfB, result.DateOfB);
        }
        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => processor.Book(null));
            Assert.Equal("request", exception.ParamName);
        }
        [Fact]
        public void ShouldSaveDeskBooking()
        {
            //Arrange
            DeskBooking savedDeskBooking = null;
            _deskBookingRepositoryMock.Setup(p => p.Save(It.IsAny<DeskBooking>())).Callback<DeskBooking>(deskBooking =>
            {
                savedDeskBooking = deskBooking;
            });
            processor.Book(_request);
            _deskBookingRepositoryMock.Verify(p => p.Save(It.IsAny<DeskBooking>()), Times.Once);
            Assert.NotNull(savedDeskBooking);
            Assert.Equal(_request.FirstName, savedDeskBooking.FirstName);
            Assert.Equal(_request.LastName, savedDeskBooking.LastName);
            Assert.Equal(_request.Email, savedDeskBooking.Email);
            Assert.Equal(_request.DateOfB, savedDeskBooking.DateOfB);
            Assert.Equal(_availableDesks.First().Id, savedDeskBooking.DeskId);
        }
        [Fact]
        public void ShouldNotSaveDeskBookingIfNoDeskAvailable()
        {
            _availableDesks.Clear();
            processor.Book(_request);
            _deskBookingRepositoryMock.Verify(x => x.Save(It.IsAny<DeskBooking>()), Times.Never);

        }
        [Theory]
        [InlineData(DeskBookingResultCode.Success, true)]
        [InlineData(DeskBookingResultCode.NoDeskAvailable, false)]
        public void ShouldReturnExpectedResultCode(DeskBookingResultCode expectedBookingResultCode, bool isDeskAvailable)
        {
            if (!isDeskAvailable)
                _availableDesks.Clear();
            var result = processor.Book(_request);
            Assert.Equal(expectedBookingResultCode, result.Code);

        }
        [Theory]
        [InlineData(5, true)]
        [InlineData(null, false)]
        public void ShouldReturnExpectedDeskBookingId(int? expectedBookingId, bool isDeskAvailable)
        {
            if (!isDeskAvailable)
                _availableDesks.Clear();
            else
            {
                _deskBookingRepositoryMock.Setup(c => c.Save(It.IsAny<DeskBooking>())).Callback<DeskBooking>(deskBooking =>
                {
                    deskBooking.Id = expectedBookingId.Value;
                });
            }
            var result = processor.Book(_request);
            Assert.Equal(expectedBookingId, result.DeskBookingId);

        }
    }
}

