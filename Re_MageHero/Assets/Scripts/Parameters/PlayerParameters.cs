using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameters : MonoBehaviour
{

    public PlayerParameters()
    {

        basePlayer = Resources.Load("Models/Characters/Piro/Player 1") as GameObject;

        Debug.Log(basePlayer);

    }


    #region Character

    public enum CharacterSpecialty
    {

        Base,
        Fire,
        Frost,
        Air,
        Necromantic

    }

    [SerializeField] private GameObject basePlayer;
    [SerializeField] private GameObject firePlayer;
    [SerializeField] private GameObject frostPlayer;
    [SerializeField] private GameObject airPlayer;
    [SerializeField] private GameObject necromanticPlayer;

    private CharacterSpecialty CurrentSpecialty = CharacterSpecialty.Base;
    public GameObject Player
    {

        get
        {

            switch (CurrentSpecialty)
            {

                case CharacterSpecialty.Base: AddSkill(basePlayer.AddComponent<PlayerMainScript>()); return basePlayer;

                case CharacterSpecialty.Fire: AddSkill(firePlayer.AddComponent<PlayerMainScript>()); return firePlayer;

                case CharacterSpecialty.Frost: AddSkill(frostPlayer.AddComponent<PlayerMainScript>()); return frostPlayer;

                case CharacterSpecialty.Air: AddSkill(airPlayer.AddComponent<PlayerMainScript>()); return airPlayer;

                case CharacterSpecialty.Necromantic: AddSkill(necromanticPlayer.AddComponent<PlayerMainScript>()); return necromanticPlayer;

                default: throw new System.Exception("Персонаж не найден");

            }

        }

    }

    #endregion

    #region Player Skill

    //Health
    private float MaxHealth;

    //damage
    private float PhysicalDamage;
    private float PhysicalDamageMultiple;

    //Resist
    private float PhysicalResist;
    private float FireResist;
    private float IceResist;
    private float PoisonResist;
    private float DarkResist;
    private float ElectricResist;

    //other
    private float Speed;
    private float AtackSpeed;

    private void AddSkill(PlayerMainScript playerScript)
    {

        MainSkillScript Skill = new MainSkillScript();

        Skill.SetMaxHealth(MaxHealth);

        Skill.SetPhysicalDamage(PhysicalDamage);
        Skill.SetPhysicalDamageMultiple(PhysicalDamageMultiple);

        Skill.SetPhysicalResist(PhysicalResist);
        Skill.SetFireResist(FireResist);
        Skill.SetIceResist(IceResist);
        Skill.SetPoisonResist(PoisonResist);
        Skill.SetDarkResist(DarkResist);
        Skill.SetElectricResist(ElectricResist);

        Skill.SetSpeed(Speed);
        Skill.SetAtackSpeed(AtackSpeed);

        switch (CurrentSpecialty)
        {

            case CharacterSpecialty.Base: break;

            case CharacterSpecialty.Fire: Skill.SetFireDamage(PhysicalDamage / 10); Skill.SetFireDamageMultiple(1); Skill.SetFireResist(0.1f); break;

            case CharacterSpecialty.Frost: Skill.SetIceDamage(PhysicalDamage / 10); Skill.SetIceDamageMultiple(1); Skill.SetIceResist(0.1f); break;

            case CharacterSpecialty.Air:  break;

            case CharacterSpecialty.Necromantic: Skill.SetDarkDamage(PhysicalDamage / 10); Skill.SetDarkDamageMultiple(1); Skill.SetDarkResist(0.1f); break;

        }

        playerScript.AddSkill(Skill);

    }

    #endregion 

    #region Coins...

    public int Mana { get; set; }
    public int Coins { get; set; }

    #endregion

}
