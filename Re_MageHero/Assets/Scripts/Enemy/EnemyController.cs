using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class EnemyController : Controller
{

    [SerializeField] protected NavMeshAgent AI;
    [SerializeField] protected GameObject EnemyManager;

    protected int XStartCell;
    protected int YStartCell;
    protected float delX;
    protected float delY;
    protected int widht;
    protected int height;

    protected Vector3 moveVector;

    protected EnemyManager manager;


    void Start()
    {

        EnemyTag = "Player";
        AI = GetComponent<NavMeshAgent>();
        manager = EnemyManager.GetComponent<EnemyManager>();

        StartCoroutine(start());

        base.Start();

        StartCoroutine("Fire");

    }

    private void Update()
    {

        base.Update();

    }

    IEnumerator start()
    {

        yield return new WaitUntil(() => manager.GetIsReady());
        manager.addEnemy(this, out XStartCell, out YStartCell, out delX, out delY, out widht, out height);

    }

    public virtual bool raycast(Transform target)
    {
        if (this.gameObject.activeInHierarchy)
        {

            Vector3 direction = target.position - transform.position;

            direction.y = 0;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit))
                if (hit.transform.Equals(target))
                {
                    AI.isStopped = true;
                    return true;
                }
            return false;

        }
        else
        {


            manager.removeEnemy(this);

            return true;

        }

    }

    public virtual void Move(bool[,] RaycastMap, Tilemap MovableMap)
    {
        if (this.gameObject.activeInHierarchy)
        {

            Vector3 position = MovableMap.WorldToCell(transform.position);

            float minCost = widht * widht + height * height;
            int minX = 0;
            int minY = 0;

            for (int x = 0; x < widht; x++)
            {

                for (int y = 0; y < height; y++)
                {

                    if (RaycastMap[x, y])
                    {

                        if (Vector3.Distance(position, new Vector3(x + XStartCell, y + YStartCell, 0)) < minCost)
                        {

                            minCost = Vector3.Distance(position, new Vector3(x + XStartCell, y + YStartCell, 0));
                            minX = x;
                            minY = y;

                        }

                    }

                }

            }


            Vector3Int moveVectorCells = new Vector3Int(minX + XStartCell, minY + YStartCell, 0);

            if (!moveVector.Equals(moveVectorCells))
            {

                moveVector = MovableMap.CellToWorld(moveVectorCells);

                moveVector = new Vector3(moveVector.x + delX / 2, moveVector.y, moveVector.z + delY / 2);

                AI.ResetPath();
                AI.SetDestination(moveVector);
                AI.isStopped = false;

            }


        }

    }

    protected override float ChangeY() => -2f;

    protected override void ChangeSomething()
    {

        AI.speed = GetSpeed();

    }

    protected override IEnumerator Fire()
    {

        bool AttackStatus = false;
        int AttackCount = 0;
        int MaxAttackCount = 60;

        while (true)
        {

            if (AttackStatus) 
            {

                AI.speed = GetSpeed() / 10;

                AttackCount++;

                if(AttackCount >= 0) { AttackCount = 0; FireForAngles(this); AttackStatus = false; }

                yield return new WaitForSeconds(((60 / GetAtackSpeed()) / 5) / MaxAttackCount);


            }
            else
            {

                AI.speed = GetSpeed();

                Vector3 target = manager.GetPlayer().position - transform.position;
                target.y = 0;

                if (Vector3.Angle(Vector3.forward, target) > 1f || Vector3.Angle(Vector3.forward, target) == 0)
                {

                    Vector3 direct = Vector3.RotateTowards(transform.forward, target, GetSpeed(), 0.0f);
                    transform.rotation = Quaternion.LookRotation(direct);

                    yield return null;

                }

                AttackCount++;

                if (AttackCount >= MaxAttackCount) { AttackCount = -MaxAttackCount; AttackStatus = true; }

                yield return new WaitForSeconds(((60 / GetAtackSpeed()) / 5 * 4) / MaxAttackCount);

            }

        }

    }


    protected  IEnumerator Fire1()
    {
        while (true)
        {

            Vector3 target = manager.GetPlayer().position - transform.position;
            target.y = 0;

            if (Vector3.Angle(Vector3.forward, target) > 1f || Vector3.Angle(Vector3.forward, target) == 0)
            {

                Vector3 direct = Vector3.RotateTowards(transform.forward, target, GetSpeed(), 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);

                yield return null;

            }

            FireForAngles(this);

            yield return new WaitForSeconds(60 / GetAtackSpeed());

        }

    }

}
