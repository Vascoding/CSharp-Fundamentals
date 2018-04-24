using System;

namespace EventImplementation
{
    public class Handler
    {
        public void OnDispatcherNameChange(NameChangeEventArgs args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }
}