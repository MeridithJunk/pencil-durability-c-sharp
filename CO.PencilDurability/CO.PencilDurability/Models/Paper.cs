using System;
using System.Collections.Generic;
using System.Text;

namespace CO.PencilDurability.Models
{
    public class Paper
    {
        public int _UpperCaseDepreciation;
        public int _OtherCaseDepreciation;
        public int _EraserDepreciation;

        public Paper(int UpperCaseDepreciation, int OtherCaseDepreciation, int EraserDepreciation)
        {
            _UpperCaseDepreciation = UpperCaseDepreciation;
            _OtherCaseDepreciation = OtherCaseDepreciation;
            _EraserDepreciation = EraserDepreciation;
        }

        public int EraserDepreciation(int totalCharacters, int CurrentEraserDurability)
        {

            return CurrentEraserDurability - (totalCharacters * _EraserDepreciation);

        }
        public int DecreasePencilDurability(char character)
        {
            if (char.IsUpper(character))
            {
                return _UpperCaseDepreciation;
            }
            else
            {
                return _OtherCaseDepreciation;
            }
        }
    }
}
