﻿

public class Enemy : MainSkillScript
{
    // Start is called before the first frame update
    public Enemy()
    {

        MaxHealth = 1000;

        Speed = 5f;

        AtackSpeed = 20;

        PhysicalDamage = 100;
        PhysicalDamageMultiple = 1f;

        Angles.Add(DegToRad(0));

    }

}