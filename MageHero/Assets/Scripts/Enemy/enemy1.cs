using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : Controller
{
    // Start is called before the first frame update
    void Start()
    {

        EnemyTag = "Player";

        AddSkill(new Player());

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

        base.Update();

    }
}
