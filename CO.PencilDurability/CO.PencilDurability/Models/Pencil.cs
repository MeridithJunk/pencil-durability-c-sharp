namespace CO.PencilDurability
{



    public class Pencil
    {

        //Model
        public int Eraser;
        public int Durability;
        public int Length;
        public int IndexOfLastRemovedWord;

        //constant for resetting durability:
        public int SetDurability;



        public Pencil(int _Durability, int _Length, int _Eraser)
        {
            Eraser = _Eraser;
            Durability = _Durability;
            Length = _Length;
            SetDurability = _Durability;
        }

        public Pencil SharpenPencil(Pencil pencil)
        {
            if (pencil.Length > 0)
            {
                pencil.Length--;
                pencil.Durability = SetDurability;
            }

            return pencil;
        }

    }
}



