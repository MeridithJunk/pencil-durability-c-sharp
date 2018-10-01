using System;
using System.Collections.Generic;
using System.Text;

namespace CO.PencilDurability
{
     public class Pencil
    {
        public int Durability { get; set; }
        public string TextWritten { get; set; }
        public int Length { get; set; }
        public int IndexOfLastRemovedWord { get; set; }
        public int Eraser { get; set; }
    }
}
