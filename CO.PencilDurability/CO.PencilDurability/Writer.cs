using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CO.PencilDurability
{
    public class Writer
    {
        public string _writeText;
        public Pencil _pencil;
        public Writer(string writeText, Pencil pencil)
        {
            _writeText = writeText;
            _pencil = pencil;

        }
        public string Write(string text)
        {
            return _writeText += text;
        }


        //To do: Maybe split into two methods? 
        public Pencil AppendWritingBasedOnPencilDurability(string text, Pencil pencil)
        {
            StringBuilder WrittenText = new StringBuilder();
            var CleanTextArray = text.ToCharArray();
            foreach (var character in CleanTextArray)
            {
                if (char.IsUpper(character) && pencil.Durability >= 2)
                {
                    WrittenText.Append(character);
                    pencil.Durability--;
                    pencil.Durability--;
                }
                else if (Char.IsWhiteSpace(character))
                {
                    WrittenText.Append(character);
                }
                else if (pencil.Durability > 0)
                {
                    WrittenText.Append(character);
                    pencil.Durability--;
                }
                else if (pencil.Durability == 0)
                {
                    WrittenText.Append(" ");
                }
            }
            pencil.TextWritten = WrittenText.ToString();
            pencil.Durability = pencil.Durability;
            return pencil;
        }


    }


}
