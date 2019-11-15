using CQRSEventSourcing1.Commands;
using CQRSEventSourcing1.Events;
using CQRSEventSourcing1.Queries;
using System;

namespace CQRSEventSourcing1.Entities
{
    public class Person
    {
        private int _age;

        private EventBroker _broker;

        public Person(EventBroker broker)
        {
            _broker = broker;

            _broker.Commands += BrokerOnCommands;

            _broker.Queries += BrokerOnQueries;
        }

        private void BrokerOnQueries(object sender, Query query)
        {
            if (query is AgeQuery ac && ac.Target == this)
            {
                ac.Result = _age;
            }
        }

        private void BrokerOnCommands(object sender, Command command)
        {
            if (command is ChangeAgeCommand cac && cac.Target == this)
            {
                if (cac.Register)
                {
                    _broker.AllEvents.Add(new AgeChangedEvent(this, _age, cac.Age));
                }

                _age = cac.Age;
            }
        }

        public bool CanDrive => _age >= 18;
    }
}
