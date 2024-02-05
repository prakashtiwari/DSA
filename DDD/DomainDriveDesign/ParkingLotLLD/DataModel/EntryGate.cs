namespace ParkingLotLLD.DataModel
{
    public class EntryGate:Gate
    {
        public DisplayBoard board;
        public EntryGate(DisplayBoard displayBoard)
        {
            this.board = displayBoard;
        }
    }
}
