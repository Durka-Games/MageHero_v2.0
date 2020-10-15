using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletMain : MonoBehaviour
{

    private Controller Controller;
    private float Speed;
    private bool IsReady = false;
    private Vector3 MoveVector;
    private string EnemyTag;

    public void Fire(Controller _controller, float _speed, Vector3 _moveVector, string _enemyTag)
    {

        MoveVector = _moveVector;
        Speed = _speed;
        Controller = _controller;
        EnemyTag = _enemyTag;

        IsReady = true;

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.gameObject.Equals(Controller.gameObject))
        {

            if (collision.gameObject.tag.Equals(EnemyTag))
            {

                collision.gameObject.SetActive(false);
                               
            }

            Destroy(this.gameObject);

        }

    }

    private void Update()
    {

        if(IsReady) transform.Translate(MoveVector * Speed * Time.deltaTime);

    }

}
