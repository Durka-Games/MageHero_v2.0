using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAdder : MonoBehaviour
{

    private bool stay = false;
    [SerializeField] Controller player;
    [SerializeField] MainSkillScript skill;

    private void Start()
    {
        skill = this.gameObject.GetComponent<MainSkillScript>();
    }

    private void OnTriggerEnter(Collider other) { if(other.gameObject.tag.Equals("Player")) stay = true; }

    private void OnTriggerExit(Collider other) { if (other.gameObject.tag.Equals("Player")) stay = false; }

    private void OnMouseDown()
    {

        if (stay)
        {

            player.AddSkill(skill);
            Destroy(this.gameObject);

        }

    }

}
