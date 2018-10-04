namespace CO.PencilDurability
{



    public class Pencil
    {
        public const int UpperCaseDepreciation = 2;
        public const int OtherCaseDepreciation = 1;
        public int Durability = 30000;
        public int Length = 10;
        public int IndexOfLastRemovedWord = 0;
        public int Eraser = 100;


        public Pencil SharpenPencil(Pencil pencil)
        {
            if (pencil.Length > 0)
            {
                pencil.Length--;
                pencil.Durability = 30000; //To Do: add to config? 
            }
            else
            {
                pencil.Durability = 0;
            }
            return pencil;
        }

    }
}



