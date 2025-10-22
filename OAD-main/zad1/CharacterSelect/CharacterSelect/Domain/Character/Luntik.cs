using CharacterSelect.Application;
using CharacterSelect.Domain.Enum;

namespace CharacterSelect.Domain.Character;

public sealed class Luntik : Entity.Character
{
    public Luntik(string name) : base(name, CharacterClass.Luntik)
    {
        Health = 99;
        Strength = 2;
        Intelligence = 34;
        Agility = 12;
        Mana = 250;
        Speed = 67;
    }
}