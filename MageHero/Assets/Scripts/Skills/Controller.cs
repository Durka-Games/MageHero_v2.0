using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Controller : Indicators
{

    private Camera Camera;
    [SerializeField] private Canvas HpBar;
    [SerializeField] private Slider HpSlider;

    public void Start()
    {

        Camera = Camera.main;
        HpSlider = HpBar.GetComponent<Slider>();

    }

    public void Update()
    {

        HpSlider.value = GetHealth() / GetMaxHealth();
        HpBar.transform.LookAt(HpBar.transform.position + Camera.transform.forward);

    }


    protected virtual IEnumerator Fire()
    {
        while (true)
        {

            Vector3 pos = transform.position;

            pos.y -= ChangeY(); 

            Instantiate(GetBullet(), pos, Quaternion.identity).GetComponent<BulletMain>().Fire(this, GetBulletSpeed(), transform.forward, EnemyTag);

            yield return new WaitForSeconds(60 / GetAtackSpeed());

        }

    }

    protected void FireForAngles(Controller _this)
    {

        double angleX = Math.Acos(transform.forward.x);
        double angleZ = Math.Asin(transform.forward.z);

        for (int i = 0; i < GetAnglesCount(); i++)
        {

            double currentAngleX = angleX + GetAngle(i); 
            double currentAngleZ = angleZ + GetAngle(i);

            Vector3 direction = new Vector3((float)Math.Cos(currentAngleX), 0, (float)Math.Sin(currentAngleZ));

            Vector3 pos = transform.position;
            pos.y += ChangeY();

            if (float.IsNaN(direction.x)) throw new Exception("а вот хуй тебе а не выстрел | " + transform.forward); //бросить ошибку в пользователя

            Instantiate(GetBullet(), pos, Quaternion.identity).GetComponent<BulletMain>().Fire(_this, GetBulletSpeed(), direction, EnemyTag);

        }

    }

    protected abstract float ChangeY();

    public void Hurt(Indicators Damage)
    {

        GetDamage(Damage.GetPhysicalDamage());

        if (GetHealth() <= 0) Death();

    }

    protected void Death()
    {

        this.gameObject.SetActive(false);

    }

}
