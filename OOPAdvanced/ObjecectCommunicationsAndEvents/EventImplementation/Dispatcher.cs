
namespace EventImplementation
{
    public delegate void NameChangeEventHandler(NameChangeEventArgs args);
    public class Dispatcher
    {
        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get { return this.Name; }
            set { NameChange(new NameChangeEventArgs(value)); }
        }

        public void OnNameChange(NameChangeEventArgs args)
        {
            NameChange(args);
        }
    }
}