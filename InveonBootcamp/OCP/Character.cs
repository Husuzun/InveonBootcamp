namespace InveonBootcamp.OCP
{
    public abstract class Character
    {
        public int Strength { get; set; }
        public int Level { get; set; }
    }

    public class Human : Character { }
    public class Goblin : Character { }
    public class Dragon : Character { }
} 