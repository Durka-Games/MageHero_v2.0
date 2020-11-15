using UnityEngine;

public class BulletMain : MonoBehaviour
{

    private Controller Controller;
    private float Speed;
    private bool IsReady = false;
    private Vector3 MoveVector;
    private string EnemyTag;

    public void Fire(Controller _controller, float _speed, Vector3 _moveVector, string _enemyTag)
    {

        transform.Translate(_moveVector);

        MoveVector = _moveVector.normalized;
        Speed = _speed;
        Controller = _controller;
        EnemyTag = _enemyTag;

        IsReady = true;

    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag.Equals("Structure") || collision.gameObject.tag.Equals(Controller.gameObject.tag) || collision.gameObject.tag.Equals(this.gameObject.tag)) return;

        if (collision.gameObject.tag.Equals(EnemyTag))
        {

            collision.gameObject.GetComponent<Controller>().Hurt(Controller);

        }

        Destroy(this.gameObject);

    }

    private void FixedUpdate()
    {

        if (IsReady) transform.Translate(MoveVector * Speed * Time.deltaTime);

    }

}
