using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Inversion
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Dependency Inversion
            Watcher watcher = new Watcher(new Writer());
            watcher.Notify("This is a message from Maguire");

            //Threading using Async, Await and Tasks
            Console.ReadKey();
        }
    }

    public class Watcher
    {
        private IWriteMessage _writer;

        public Watcher(IWriteMessage concreteWriter)
        {
            _writer = concreteWriter;
        }

        public void Notify(string message)
        {
            _writer.AddMessageToScreen(message);
        }
    }

    public class Writer : IWriteMessage
    {
        public void AddMessageToScreen(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface IWriteMessage
    {
        void AddMessageToScreen(string message);
    }
}
