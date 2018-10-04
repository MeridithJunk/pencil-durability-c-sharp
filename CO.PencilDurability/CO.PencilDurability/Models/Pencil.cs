namespace CO.PencilDurability
{



    public class Pencil
    {
        public const int UpperCaseDepreciation = 2;
        public const int OtherCaseDepreciation = 1;
        public const int SetDurability = 30000;
        public const int SetLength = 10;
        public const int SetEraser = 100;

        public int Durability = SetDurability;
        public int Length = SetLength;
        public int IndexOfLastRemovedWord = 0;
        public int Eraser = SetEraser;
        public int EraserDurability = 1; 

        public Pencil SharpenPencil(Pencil pencil)
        {
            if (pencil.Length > 0)
            {
                pencil.Length--;
                pencil.Durability = SetDurability;
            }
            else
            {
                pencil.Durability = 0;
            }
            return pencil;
        }

        public int DecreaseDurability(char character)
        {

            if (char.IsUpper(character))
            {
                return UpperCaseDepreciation;
            }
            else
            {
                return OtherCaseDepreciation;
            }
        }
    }
}



