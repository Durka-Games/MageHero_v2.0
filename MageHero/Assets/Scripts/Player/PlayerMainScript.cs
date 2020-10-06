using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainScript : Controller
{

    public void Start()
    {

        SetMaxHealth(100);
        Regen(100);

        base.Start();

    }

    private void Update()
    {

        
        Atack(2 * Time.deltaTime);

        base.Update();

    }

}
