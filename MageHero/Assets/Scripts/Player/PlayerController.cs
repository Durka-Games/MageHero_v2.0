using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private PlayerMainScript Player;
    private Camera Camera;
    [SerializeField] private Canvas HpBar;

    public void Start()
    {

        Camera = Camera.main;

    }

    private void Update()
    {

        HpBar.transform.LookAt(HpBar.transform.position + Camera.transform.forward);

    }

}
