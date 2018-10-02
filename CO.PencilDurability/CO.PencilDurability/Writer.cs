using System;
using System.Text;

namespace CO.PencilDurability
{
    public class Writer
    {
        public string _writeText;
        public Pencil _pencil;
        public Writer(Pencil pencil)
        {
            _pencil = pencil;

        }
        public string Write(string text)
        {
            return _writeText += AppendWritingBasedOnPencilDurability(text);
        }


        //To do: Maybe split into two methods? 
        public string AppendWritingBasedOnPencilDurability(string text)
        {
            StringBuilder WrittenText = new StringBuilder();
            var CleanTextArray = text.ToCharArray();
            foreach (var character in CleanTextArray)
            {
                if (char.IsUpper(character) && _pencil.Durability >= 2)
                {
                    WrittenText.Append(character);
                    _pencil.Durability--;
                    _pencil.Durability--; //Removing two for capitals
                }
                else if (Char.IsWhiteSpace(character))
                {
                    WrittenText.Append(character);
                }
                else if (_pencil.Durability > 0)
                {
                    WrittenText.Append(character);
                    _pencil.Durability--; // Removing one for all others 
                }
                else if (_pencil.Durability == 0)
                {
                    WrittenText.Append(" ");
                }
            }
            return WrittenText.ToString();
        }


    }


}
