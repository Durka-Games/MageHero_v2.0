using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSkill : MainSkillScript
{
    
    public TestSkill()
    {

        Angles.Add(DegToRad(15));
        Angles.Add(DegToRad(-15));

        PhysicalDamage = 100;

    }
    
}
