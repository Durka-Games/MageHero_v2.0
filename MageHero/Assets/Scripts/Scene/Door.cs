using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private EnemyManager EnemyManager;

    private void OnTriggerEnter(Collider other)
    {

        if (EnemyManager.GetEnemies().Length == 0) MainSceneScript.NextLevel();

    }
}
