

public class Player : MainSkillScript
{

    public Player()
    {

        MaxHealth = 1000;

        Speed = 5f;

        AtackSpeed = 40;

        PhysicalDamage = 200;
        PhysicalDamageMultiple = 1f;

        Angles.Add(DegToRad(0));
        Angles.Add(DegToRad(30));
        Angles.Add(DegToRad(-30));

    }

}
