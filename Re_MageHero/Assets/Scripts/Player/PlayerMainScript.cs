using System;
using System.Collections;
using UnityEngine;

public class PlayerMainScript : Controller
{

    private float gravityForce;
    private Vector3 moveVector;
    private bool IsMoving = true;
    private MobileController controller;

    private CharacterController ch_controller;

    private Animator animator;

    [SerializeField] EnemyManager EnemyManager;

    public void Start()
    {

        EnemyTag = "Enemy";

        base.Start();

        ch_controller = GetComponent<CharacterController>();
        controller = GameObject.FindGameObjectWithTag("Joystic").GetComponent<MobileController>();
        animator = GetComponent<Animator>();

        StartCoroutine("Fire");

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

        IsMoving = !moveVector.Equals(Vector3.zero);

        moveVector.y = gravityForce;
        ch_controller.Move(moveVector * Time.deltaTime);

    }

    private void GameGravity()
    {

        if (!ch_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;

    }

    protected override float ChangeY() => -1.4f;

    protected override IEnumerator Fire()
    {

        while (true)
        {

            if(EnemyManager.GetEnemies().Length == 0 && EnemyManager.isEnemyAtLevel()) yield break;

            yield return new WaitUntil(() => !IsMoving);

            Vector3 target = GetEnemyPos() - transform.position;
            target.y = 0;

            if (Vector3.Angle(Vector3.forward, target) > 1f || Vector3.Angle(Vector3.forward, target) == 0)
            {

                Vector3 direct = Vector3.RotateTowards(transform.forward, target, GetSpeed(), 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);

                yield return null;

            }

            try
            {

                FireForAngles(this);

            }
            catch (Exception ex) { Debug.Log(ex.Message);  }

            yield return new WaitForSeconds(60 / GetAtackSpeed());

        }

    }

    private Vector3 GetEnemyPos()
    {

        try
        {

            EnemyController[] enemies = EnemyManager.GetEnemies();

            RaycastHit[] hits = new RaycastHit[enemies.Length];

            for (int i = 0; i < enemies.Length; i++)
            {

                Vector3 direction = enemies[i].gameObject.transform.position - transform.position;

                Physics.Raycast(transform.position, direction, out hits[i]);

            }

            int BestSeen = -1;
            int BestInvisible = -1;

            int Best = 0;

            for (int i = 0; i < enemies.Length; i++)
            {

                if (hits[i].distance < hits[Best].distance) Best = i;

            }

            return enemies[Best].transform.position;

            if (BestSeen != -1) return enemies[BestSeen].transform.position;
            if (BestInvisible != -1) return enemies[BestInvisible].transform.position;
            return Vector3.zero;

        }
        catch (Exception) { return Vector3.zero; }

    }

}
