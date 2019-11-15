using CQRSEventSourcing1.Entities;

namespace CQRSEventSourcing1.Queries
{
    public class AgeQuery : Query
    {
        public Person Target { get; set; }

        public AgeQuery(Person target)
        {
            Target = target;
        }
    }
}
