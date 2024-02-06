namespace SnakeAndLadder.Model.DomainModel
{
    public abstract class ForeignEntity
    {
        public EntityType EntityType { get; set; }

        public int FromPosition { get; set; }
        public int ToPosition { get; set; }

    }
}
