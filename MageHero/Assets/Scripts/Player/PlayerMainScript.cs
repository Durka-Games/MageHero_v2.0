using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainScript : Controller
{

    private float gravityForce;
    private Vector3 moveVector;
    private MobileController controller;

    private CharacterController ch_controller;

    private Animator animator;

    public void Start()
    {

        EnemyTag = "Enemy";

        AddSkill(new Player());

        base.Start();

        ch_controller = GetComponent<CharacterController>();
        controller = GameObject.FindGameObjectWithTag("Joystic").GetComponent<MobileController>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {

        CharacterMoving();
        GameGravity();

        base.Update();

    }

    private void CharacterMoving()
    {

        moveVector = Vector3.zero;
        moveVector.x = controller.Horizontal() * GetSpeed();
        moveVector.z = controller.Vertival() * GetSpeed();


        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {

            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, GetSpeed(), 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);

        }


        moveVector.y = gravityForce;
        ch_controller.Move(moveVector * Time.deltaTime);

    }

    private void GameGravity()
    {

        if (!ch_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;

    }

}
