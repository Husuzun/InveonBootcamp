using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonBootcamp.OCP
{
    public class OldDamageCalculator
    {
        public double CalculateDamage(OldCharacter character)
        {
            if (character.Type == "Human")
            {
                return character.Strength * character.Level;
            }
            else if (character.Type == "Goblin")
            {
                return character.Strength * character.Level/2;
            }
            return 0;
        }
    }
}
