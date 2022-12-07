using Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public abstract class TestBase : IDisposable
    {
        public TestBase()
        {
            Runner = new Runner();
        }

        public void Dispose()
        {
            // Do "global" teardown here; Called after every test method.
        }
        public Runner Runner { get; private set; }
    }
}
