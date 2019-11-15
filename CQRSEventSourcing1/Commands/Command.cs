using System;

namespace CQRSEventSourcing1.Commands
{
    public abstract class Command : EventArgs
    {
        public bool Register { get; set; }

        public Command()
        {
            Register = true;
        }
    }
}