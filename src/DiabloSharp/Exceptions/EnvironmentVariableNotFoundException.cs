using System;

namespace DiabloSharp.Exceptions
{
    public class EnvironmentVariableNotFoundException : Exception
    {
        public EnvironmentVariableNotFoundException(string name)
            : base($"Cannot find environment variable \"{name}\"")
        {
        }
    }
}
