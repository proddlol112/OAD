using CharacterSelect.Application;
using CharacterSelect.Domain.Enum;

namespace CharacterSelect.Domain.Character;

public sealed class Artem : Entity.Character
{
    public Artem(string name) : base(name, CharacterClass.Artem)
    {
        Health = 56;
        Strength = 5;
        Intelligence = 8;
        Agility = 5;
        Mana = 100;
        Speed = 35;
    }
}