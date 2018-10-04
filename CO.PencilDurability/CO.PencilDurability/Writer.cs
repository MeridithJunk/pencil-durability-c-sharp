using CO.PencilDurability.Models;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CO.PencilDurability
{
    public class Writer
    {
        public string _writeText;
        public Pencil _pencil;
        public Paper _paper;

        public Writer(Pencil pencil, Paper paper)
        {
            _pencil = pencil;
            _paper = paper;

        }

        public string Write(string text)
        {
            StringBuilder WrittenText = new StringBuilder();
            var CleanTextArray = text.ToCharArray();
            foreach (var character in CleanTextArray)
            {
                if (char.IsUpper(character) && _pencil.Durability >= 2)
                {
                    WrittenText.Append(character);
                    _pencil.Durability -= _paper.DecreasePencilDurability(character);
                }
                else if (Char.IsWhiteSpace(character))
                {
                    WrittenText.Append(character);
                }
                else if (_pencil.Durability > 0)
                {
                    WrittenText.Append(character);
                    _pencil.Durability -= _paper.DecreasePencilDurability(character);
                }
                else if (_pencil.Durability == 0)
                {
                    WrittenText.Append(" ");
                }
            }
            return _writeText += WrittenText.ToString();
        }



        public string EraseWord(string text, string ErasedWord)
        {
            var erasedLength = ErasedWord.Length;
            var indexinText = Regex.Match(text, @"\W" + ErasedWord + @"\W", RegexOptions.RightToLeft).Index;

            if (erasedLength <= _pencil.Eraser)
            {
                _pencil.Eraser = _paper.EraserDepreciation(erasedLength, _pencil.Eraser);
                return text.Remove(indexinText, ErasedWord.Length + 1).Insert(indexinText, new String(' ', erasedLength + 1));
            }
            else
            {
                var AvailableErased = ErasedWord.Remove(erasedLength - _pencil.Eraser);
                AvailableErased += new String(' ', _pencil.Eraser);
                _pencil.Eraser = 0;
                return text.Remove(indexinText, erasedLength + 1).Insert(indexinText, " " + AvailableErased);
            }
        }

        public string RemoveWord(string text, string editedWord)
        {
            var RemoveSpaces = new String(' ', editedWord.Length + 2);
            var indexinText = text.LastIndexOf(RemoveSpaces);
            _pencil.IndexOfLastRemovedWord = indexinText + 1;
            return text.Remove(indexinText, RemoveSpaces.Length).Insert(indexinText, ' ' + editedWord + ' ');
        }


        public string ReplaceWord(string text, string replacementWord, int IndexOfLastRemovedWord)
        {
            var textArray = text.ToArray();
            int CountOfCharacters = 0;

            for (int i = 0; i < replacementWord.Length; i++)
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
