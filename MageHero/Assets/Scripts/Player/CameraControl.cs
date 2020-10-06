using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private bool isOnlyZ = false;
    [SerializeField] private Transform player;

    private Vector3 startPos;

    private void Start()
    {

        startPos = transform.position;

    }

    private void Update()
    {

        if (isOnlyZ)
        {

            Vector3 pos = startPos;
            pos.z = player.position.z - 10;

            transform.position = pos;

        }
        else
        {

            Vector3 pos = player.position;

            pos.y += 10;
            pos.z -= 5;

            transform.position = pos;

        }

    }

}
