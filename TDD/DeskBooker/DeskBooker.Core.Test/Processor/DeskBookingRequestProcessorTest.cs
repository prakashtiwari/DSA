using DeskBooker.Core.Domain;
using Xunit.Sdk;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTest
    {
        [Fact]
        public void ShouldReturnDeskBookingResultWithValues()
        {
            //Arrange
            var request = new DeskBookingRequest()
            {
                FirstName = "Prakash",
                LastName = "Tiwari",
                Email = "p@t.com",
                DateOfB = new DateTime(1986, 1, 22)
            };
            //Act
            var processor = new DeskBookingRequestProcessor();
            DeskBookingResult result = processor.Book(request);
            Assert.NotNull(result);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.DateOfB, result.DateOfB);
        }
        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var processor = new DeskBookingRequestProcessor();
            var exception = Assert.Throws<ArgumentNullException>(() => processor.Book(null));
            Assert.Equal("request", exception.ParamName);
        }
    }
}

