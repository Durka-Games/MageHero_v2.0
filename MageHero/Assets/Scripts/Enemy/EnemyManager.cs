using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] private bool isEnemySpawn;
    private bool isEnemyAdd = false;
    public bool isEnemyAtLevel() => isEnemySpawn && isEnemyAdd;

    [SerializeField] protected Tilemap MovableMap;
    [SerializeField] protected int XStartPos;
    [SerializeField] protected int YStartPos;

    [SerializeField] protected float XStartPosWorld;
    [SerializeField] protected float YStartPosWorld;

    protected bool[,] isMovable;
    protected bool[,] isRayCast;

    public string[] surface;

    [SerializeField] protected int width = 9;
    [SerializeField] protected int height = 16;

    [SerializeField] protected float delWidth;
    [SerializeField] protected float delHeight;

    [SerializeField] protected Transform player;
    public Transform GetPlayer() => player;

    protected bool isReady = false;

    public bool GetIsReady() { return isReady; }

    protected List<EnemyController> enemy = new List<EnemyController>();
    public EnemyController[] GetEnemies() => enemy.ToArray();

    // Start is called before the first frame update
    void Start()
    {

        isMovable = new bool[width, height];
        isRayCast = new bool[width, height];

        for (int x = XStartPos; x < XStartPos + width; x++)
            for (int y = YStartPos; y < YStartPos + height; y++)
                isMovable[x - XStartPos, y - YStartPos] = Contains(MovableMap.GetTile(new Vector3Int(x, y, 0)));

        delWidth = (MovableMap.CellToWorld(new Vector3Int(1, 1, 0)) - MovableMap.CellToWorld(new Vector3Int(0, 0, 0))).x;
        delHeight = (MovableMap.CellToWorld(new Vector3Int(1, 1, 0)) - MovableMap.CellToWorld(new Vector3Int(0, 0, 0))).z;

        XStartPosWorld = MovableMap.CellToWorld(new Vector3Int(XStartPos, YStartPos, 0)).x;
        YStartPosWorld = MovableMap.CellToWorld(new Vector3Int(XStartPos, YStartPos, 0)).z;

        isReady = true;

    }

    private void Update()
    {

        List<EnemyController> needRaycastMap = new List<EnemyController>();

        for (int i = 0; i < enemy.Count; i++) if (!enemy[i].raycast(player)) needRaycastMap.Add(enemy[i]);

        if (needRaycastMap.Count != 0)
        {

            FillRayCastMap();

            for (int i = 0; i < needRaycastMap.Count; i++) needRaycastMap[i].Move(isRayCast, MovableMap);

        }

    }

    private bool Contains(TileBase tileBase)
    {

        bool isMove = false;

        for (int i = 0; i < surface.Length; i++) if (surface[i].Equals(tileBase.name)) isMove = true;

        return isMove;

    }

    protected void FillRayCastMap()
    {

        int CellsX = 0;
        int CellsY = 0;

        for (float x = XStartPosWorld; x < XStartPosWorld + width * delWidth; x += delWidth)
        {

            CellsY = 0;

            for (float y = YStartPosWorld; y < YStartPosWorld + height * delHeight; y += delHeight)
            {

                if (isMovable[CellsX, CellsY])
                {

                    RaycastHit hit;

                    transform.position = new Vector3(x + delWidth / 2, PlayerTransform().y, y + delHeight / 2);
                    Vector3 direction = PlayerTransform() - transform.position;

                    if (Physics.Raycast(transform.position, direction, out hit)) isRayCast[CellsX, CellsY] = hit.transform.Equals(player);

                }
                else isRayCast[CellsX, CellsY] = false;

                CellsY++;

            }

            CellsX++;

        }


    }

    private Vector3 PlayerTransform()
    {

        Vector3 pos = player.position;

        pos.y += 0.5f;

        return pos;

    }

    public void addEnemy(EnemyController _enemy, out int XstartCell, out int YStartCell, out float delX, out float delY, out int widht, out int height)
    {

        isEnemyAdd = true;

        if (!enemy.Contains(_enemy))
            enemy.Add(_enemy);

        XstartCell = XStartPos;
        YStartCell = YStartPos;
        delX = delWidth;
        delY = delHeight;
        widht = this.width;
        height = this.height;

    }

    public void removeEnemy(EnemyController _enemy)
    {

        if (enemy.Contains(_enemy))
            enemy.Remove(_enemy);


    }

}
