using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var indexinText = text.LastIndexOf(" " + ErasedWord + " ");

            if (erasedLength <= _pencil.Eraser)
            {
                _pencil.Eraser = _pencil.Eraser - erasedLength;
                return text.Remove(indexinText, ErasedWord.Length + 2).Insert(indexinText, new String(' ', erasedLength + 2));
            }
            else
            {
                var AvailableErased = ErasedWord.Remove(erasedLength - _pencil.Eraser);
                AvailableErased += new String(' ', _pencil.Eraser);
                _pencil.Eraser = 0;
                return text.Remove(indexinText, erasedLength + 2).Insert(indexinText, ' ' + AvailableErased + ' ');
            }
        }

        public string EditTextRemoveWord(string text, string editedWord)
        {
            var RemoveSpaces = new String(' ', editedWord.Length + 2);
            var indexinText = text.LastIndexOf(RemoveSpaces);
            _pencil.IndexOfLastRemovedWord = indexinText + 1;
            return text.Remove(indexinText, RemoveSpaces.Length).Insert(indexinText, ' ' + editedWord + ' ');
        }

        public string ReplaceinText(string text, string replacementWord, int IndexOfLastRemovedWord)
        {
            var textArray = text.ToArray();
            int CountOfCharacters = 0;

            for (int i = IndexOfLastRemovedWord; i < replacementWord.Length + 3; i++)
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
