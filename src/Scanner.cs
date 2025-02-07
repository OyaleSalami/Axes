using System;
using System.Collections.Generic;

namespace Axes
{
    class Scanner
    {
        public List<Token> tokens;

        public Scanner(string source) 
        {
            tokens = new List<Token>();
        }
    }
}
