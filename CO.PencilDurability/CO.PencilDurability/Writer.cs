using System;
using System.Collections.Generic;
using System.Text;

namespace CO.PencilDurability
{
    public class Writer
    {
        public string _writeText; 
        public Writer(string writeText)
        {

            _writeText = writeText; 
        }
        public string Write(string text)
        {

            return _writeText += text;
        }
    }
}
