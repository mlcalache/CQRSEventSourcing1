using CQRSEventSourcing1.Entities;

namespace CQRSEventSourcing1.Events
{
    public class AgeChangedEvent : Event
    {
        public Person Target { get; set; }
        public int OldValue { get; set; }
        public int NewValue { get; set; }

        public AgeChangedEvent(Person target, int oldValue, int newValue)
        {
            Target = target;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return $"Age changed from {OldValue} to {NewValue}";
        }
    }
}