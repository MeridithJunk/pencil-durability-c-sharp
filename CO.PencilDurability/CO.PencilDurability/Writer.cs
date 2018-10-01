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

        public Pencil AppendWritingBasedOnPencilDurability(string text, Pencil Pencil)
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
                else if(Pencil.Durability == 0)
                {
                    WrittenText.Append(" ");


                }


            }
            pencil.TextWritten = WrittenText.ToString();
            pencil.Durability = Pencil.Durability;
            return pencil;

        }

        public Pencil CreatePencil()
        {
            Pencil NewPencil = new Pencil();
            NewPencil.Durability = 100;
            NewPencil.Length = 3; 
            return NewPencil; 

        }

        public void SharpenPencil()
        {
            if (_pencil.Length > 0)
            {
                _pencil.Length--;
                _pencil.Durability = 40000;
            }
            else{
                _pencil.Durability = 0;

            }

        }

        public string EraseWordFromText(string text, string erase)
        {
            var erasedLength = erase.Length;
            if (erasedLength < _pencil.Eraser)
            {
                _pencil.Eraser = _pencil.Eraser - erasedLength;
                var indexinText = text.LastIndexOf(erase);
                return text.Remove(indexinText, erase.Length).Insert(indexinText, new String(' ', _pencil.Eraser));
            }
            else
            {
                var AvailableErased = erase.Remove(erase.Length - _pencil.Eraser);
                var indexinText = text.LastIndexOf(erase);
                AvailableErased += new String(' ', _pencil.Eraser);
                _pencil.Eraser = 0; 
              return  text.Remove(indexinText, erase.Length).Insert(indexinText, AvailableErased);
            }
        }

        public string EditText(string text, string editedWord)
        {
            var RemoveSpaces = new String(' ', editedWord.Length + 2);
            var indexinText = text.LastIndexOf(RemoveSpaces);
            return text.Remove(indexinText, RemoveSpaces.Length).Insert(indexinText, ' ' + editedWord + ' ');
        }

        public string replaceinText()
        {

            var text = "An       a day keeps the doctor away";
            var addword = "artichoke";
            int index = 3;
            var textArray = text.ToArray();
            int num = 0;

            for (int i = index; i < addword.Length + 3; i++)
            {
                var character = textArray[i].ToString();

                if (String.IsNullOrWhiteSpace(character))
                {

                    var firstcharacter = addword.ToArray();
                    textArray[i] = firstcharacter[num];
                    num++;
                }
                else
                {

                    textArray[i] = '@';
                    num++;
                }
            }
            return string.Concat(textArray);
        }
    }


}
