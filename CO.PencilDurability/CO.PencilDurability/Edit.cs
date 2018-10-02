using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
            var indexinText = Regex.Match(text, @"\W" + ErasedWord + @"\W", RegexOptions.RightToLeft).Index;

            if (erasedLength <= _pencil.Eraser)
            {
                _pencil.Eraser = _pencil.Eraser - erasedLength;
                return text.Remove(indexinText, ErasedWord.Length + 1).Insert(indexinText, new String(' ', erasedLength + 1));
            }
            else
            {
                var AvailableErased = ErasedWord.Remove(erasedLength - _pencil.Eraser);
                AvailableErased += new String(' ', _pencil.Eraser);
                _pencil.Eraser = 0;
                return text.Remove(indexinText, erasedLength + 1).Insert(indexinText, " " +  AvailableErased);
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

            for (int i = 0; i < replacementWord.Length - 1; i++)
            {
                var character = textArray[IndexOfLastRemovedWord].ToString();

                if (String.IsNullOrWhiteSpace(character))
                {
                    var firstcharacter = replacementWord.ToArray();
                    textArray[IndexOfLastRemovedWord] = firstcharacter[CountOfCharacters];
                    CountOfCharacters++;
                    IndexOfLastRemovedWord++;
                }
                else
                {
                    textArray[IndexOfLastRemovedWord] = '@';
                    CountOfCharacters++;
                    IndexOfLastRemovedWord++; 
                }
            }
            return string.Concat(textArray);
        }
    }
}
