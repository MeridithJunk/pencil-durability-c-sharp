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

        public string AppendWritingBasedOnPencilDurability(string text, Pencil Pencil)
        {
            StringBuilder WrittenText = new StringBuilder();
            var CleanTextArray = text.ToCharArray();
            Pencil pencil = new Pencil();
            foreach (var character in CleanTextArray)
            {
                if (char.IsUpper(character) && Pencil.Durability >= 2)
                {
                    WrittenText.Append(character);
                    Pencil.Durability--;
                    Pencil.Durability--;
                }
                else if (Char.IsWhiteSpace(character))
                {
                    WrittenText.Append(character);
                }
                else if (Pencil.Durability > 0)
                {
                    WrittenText.Append(character);
                    Pencil.Durability--;
                }

            }

            pencil.Durability = Pencil.Durability;
            return WrittenText.ToString();

        }

        public Pencil CreatePencil()
        {
            Pencil NewPencil = new Pencil();
            NewPencil.Durability = 100;
            return NewPencil; 

        }

        
    }


}
