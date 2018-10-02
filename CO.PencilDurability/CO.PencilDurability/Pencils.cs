namespace CO.PencilDurability
{
    public class Pencils
    {

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

        public Pencil CreatePencil()
        {
            Pencil NewPencil = new Pencil
            {
                Durability = 30000, //To Do: add to config? 
                Length = 10, //To Do: add to config? 
                Eraser = 100
            };
            return NewPencil;

        }
    }
}
