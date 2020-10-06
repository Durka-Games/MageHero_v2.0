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

    }

    public void Update()
    {

        HpSlider.value = GetHealth() / GetMaxHealth();
        HpBar.transform.LookAt(HpBar.transform.position + Camera.transform.forward);

    }

}
