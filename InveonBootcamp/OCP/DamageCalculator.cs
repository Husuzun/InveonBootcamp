namespace InveonBootcamp.OCP
{
    public class DamageCalculator
    {
        public static decimal CalculateDamageDelegate(int strength, int level, Func<int, int, decimal> damageFunc)
        {
            return damageFunc(strength, level);
        }
    }
} 