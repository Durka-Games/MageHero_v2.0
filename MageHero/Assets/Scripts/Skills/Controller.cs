using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : Indicators
{

    private Camera Camera;
    [SerializeField] private Canvas HpBar;
    [SerializeField] private Slider HpSlider;

    public void Start()
    {

        Camera = Camera.main;
        HpSlider = HpBar.GetComponent<Slider>();

        StartCoroutine("Fire");

    }

    public void Update()
    {

        HpSlider.value = GetHealth() / GetMaxHealth();
        HpBar.transform.LookAt(HpBar.transform.position + Camera.transform.forward);

    }


    IEnumerator Fire()
    {
        while (true)
        {

            Vector3 pos = transform.position;

            pos.y -= 2f; //1.4

            Instantiate(GetBullet(), pos, Quaternion.identity).GetComponent<BulletMain>().Fire(this, GetBulletSpeed(), transform.forward, EnemyTag);

            yield return new WaitForSeconds(60 / GetAtackSpeed());

        }

    }

}
