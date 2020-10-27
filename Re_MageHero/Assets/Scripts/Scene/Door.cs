using System;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private EnemyManager EnemyManager;

    private void OnTriggerEnter(Collider other)
    {

        try
        {
            if(other.gameObject.tag.Equals("Player"))
                if (EnemyManager.GetEnemies().Length == 0) MainSceneScript.NextLevel();

        }
        catch (Exception e) { Debug.Log(e.Message); }

    }
}
