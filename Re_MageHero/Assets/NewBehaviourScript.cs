using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    public void Script()
    {

        Instantiate(Parameters.PlayerParameters.Player, Vector3.zero, Quaternion.identity);

    }

}
