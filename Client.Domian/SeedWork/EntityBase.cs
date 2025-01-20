namespace Client.Domian.Common
{
    public abstract class EntityBase<TId>
    {
        public TId Id { get; set; }

        //Implemnet in future
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}
