using CharacterSelect.Application;
using CharacterSelect.Domain.Enum;

namespace CharacterSelect.Domain.Character;

public sealed class Kolia : Entity.Character
{
    public Kolia(string name) : base(name, CharacterClass.Kolia)
    {
        Health = 85;
        Strength = 3;
        Intelligence = 7;
        Agility = 15;
        Mana = 80;
        Speed = 40;
    }
}