using CQRSEventSourcing1.Commands;
using CQRSEventSourcing1.Entities;
using CQRSEventSourcing1.Events;
using CQRSEventSourcing1.Queries;
using System;

namespace CQRSEventSourcing1
{
    class Program
    {
        static void Main(string[] args)
        {
            var eb = new EventBroker();
            var p = new Person(eb);

            eb.Command(new ChangeAgeCommand(p, 123));

            foreach (var e in eb.AllEvents)
            {
                Console.WriteLine(e);
            }

            int age;

            age = eb.Query<int>(new AgeQuery(p));

            Console.WriteLine(age);

            eb.UndoLast();

            foreach (var e in eb.AllEvents)
            {
                Console.WriteLine(e);
            }

            age = eb.Query<int>(new AgeQuery(p));

            Console.WriteLine(age);

            Console.ReadKey();
        }
    }
}
