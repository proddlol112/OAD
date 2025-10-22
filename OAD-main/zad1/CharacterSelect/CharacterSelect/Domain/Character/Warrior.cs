using CharacterSelect.Application;
using CharacterSelect.Domain.Enum;

namespace CharacterSelect.Domain.Character;

public sealed class Warrior : Entity.Character
{
    public Warrior(string name) : base(name, CharacterClass.Warrior)
    {
        Health = 120;
        Strength = 14;
        Intelligence = 6;
        Agility = 8;
        Mana = 100;
        Speed = 35;
        
    }
}