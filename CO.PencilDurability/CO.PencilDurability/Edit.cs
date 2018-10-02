using System;
using System.Linq;

namespace CO.PencilDurability
{
    public class Edit        
    {
        private Pencil _pencil; 
        public Edit(Pencil pencil)
        {
            _pencil = pencil; 
        }

        public string EraseWordFromText(string text, string ErasedWord)
        {
            var erasedLength = ErasedWord.Length;
            var indexinText = text.LastIndexOf(ErasedWord); ;

            if (erasedLength <= _pencil.Eraser)
            {
                _pencil.Eraser = _pencil.Eraser - erasedLength;
                return text.Remove(indexinText, ErasedWord.Length ).Insert(indexinText, new String(' ', erasedLength));
            }
            else
            {
                var AvailableErased = ErasedWord.Remove(erasedLength - _pencil.Eraser);
                AvailableErased += new String(' ', _pencil.Eraser);
                _pencil.Eraser = 0;
                return text.Remove(indexinText, erasedLength).Insert(indexinText,  AvailableErased );
            }
        }

        public string EditTextRemoveWord(string text, string editedWord)
        {
            var RemoveSpaces = new String(' ', editedWord.Length + 2);
            var indexinText = text.LastIndexOf(RemoveSpaces);
            _pencil.IndexOfLastRemovedWord = indexinText + 1;
            return text.Remove(indexinText, RemoveSpaces.Length).Insert(indexinText, ' ' + editedWord + ' ');
        }

        public string ReplaceinText(string text, string replacementWord)
        {
            var textArray = text.ToArray();
            int CountOfCharacters = 0;

            for (int i = _pencil.IndexOfLastRemovedWord; i < replacementWord.Length + 3; i++)
            {
                var character = textArray[i].ToString();

                if (String.IsNullOrWhiteSpace(character))
                {

                    var firstcharacter = replacementWord.ToArray();
                    textArray[i] = firstcharacter[CountOfCharacters];
                    CountOfCharacters++;
                }
                else
                {
                    textArray[i] = '@';
                    CountOfCharacters++;
                }
            }
            return string.Concat(textArray);
        }
    }
}
