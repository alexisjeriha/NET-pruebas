namespace Business.Entities
{
    public class BusinessEntity
    {
        public BusinessEntity()
        {
            State = States.New;
        }

        public int ID { get; set; }

        public States State { get; set; }

        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }


    }
}
