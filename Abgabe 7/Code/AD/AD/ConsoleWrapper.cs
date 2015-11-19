using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AD
{
    internal class ConsoleWrapper : IDisposable
    {
        public string Filename
        {
            get;
            private set;
        }

        private TextWriter stdout, wrapper;

        public ConsoleWrapper(string filename)
        {
            Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), filename);

            wrapper = new StreamWriter(Filename);
            stdout = Console.Out;

            Console.SetOut(wrapper);
        }

        public void Dispose()
        {
            wrapper.Flush();

            wrapper.Close();
            wrapper.Dispose();

            Console.SetOut(stdout);
        }
    }
}
