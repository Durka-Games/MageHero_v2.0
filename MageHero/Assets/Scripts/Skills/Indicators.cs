﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicators
{

    //health
    private float Health;
    private float MaxHealth;
    private float BaseMaxHealth;

    protected float GetHealth() => Health;
    protected void Regen(float value) => Health = (Health + value <= MaxHealth ? Health + value : MaxHealth);
    protected void SetMaxHealth(float value) => MaxHealth += value;

    //damage
    private float BasePhysicalDamage;
    private float PhysicalDamage;
    private float PhysicalDamageMultiple;

    private float BaseFireDamage;
    private float FireDamage;
    private float FireDamageMultiple;

    private float BaseIceDamage;
    private float IceDamage;
    private float IceDamageMultiple;

    private float BasePoisonDamage;
    private float PoisonDamage;
    private float PoisonDamageMultiple;

    private float BaseDarkDamage;
    private float DarkDamage;
    private float DarkDamageMultiple;

    private float BaseElectricDamage;
    private float ElectricDamage;
    private float ElectricDamageMultiple;

    protected float GetPhysicalDamage() => PhysicalDamage * PhysicalDamageMultiple;
    protected float GetFireDamage() => FireDamage * FireDamageMultiple;
    protected float GetIceDamage() => IceDamage * IceDamageMultiple;
    protected float GetPoisonDamage() => PoisonDamage * PoisonDamageMultiple;
    protected float GetDarkDamage() => DarkDamage * DarkDamageMultiple;
    protected float GetElectricDamage() => ElectricDamage * ElectricDamageMultiple;

    //resistance
    private float PhysicalResist;
    private float FireResist;
    private float IceResist;
    private float PoisonResist;
    private float DarkResist;
    private float ElectricResist;

    protected float GetPhysicalResist() => PhysicalResist;
    protected float GetFireResist() => FireResist;
    protected float GetIceResist() => IceResist;
    protected float GetPoisonResist() => PoisonResist;
    protected float GetDarkResist() => DarkResist;
    protected float GetElectricResist() => ElectricResist;

    //skills
    private List<MainSkillScript> Skills;

    protected void AddSkill(MainSkillScript _skill)
    {

        Skills.Add(_skill);

        MaxHealth = BaseMaxHealth;

        PhysicalDamage = BasePhysicalDamage;
        FireDamage = BaseFireDamage;
        IceDamage = BaseIceDamage;
        PoisonDamage = BasePoisonDamage;
        DarkDamage = BaseDarkDamage;
        ElectricDamage = BaseElectricDamage;

        PhysicalDamageMultiple = 0f;
        FireDamageMultiple = 0f;
        IceDamageMultiple = 0f;
        PoisonDamageMultiple = 0f;
        DarkDamageMultiple = 0f;
        ElectricDamageMultiple = 0f;

        PhysicalResist = 0f;
        FireResist = 0f;
        IceResist = 0f;
        PoisonResist = 0f;
        DarkResist = 0f;
        ElectricResist = 0f;

        for (int i = 0; i < Skills.Count; i++)
        {

            PhysicalDamage += Skills[i].GetPhysicalDamage();
            PhysicalDamageMultiple += Skills[i].GetPhysicalDamageMultiple();
            PhysicalResist += Skills[i].GetPhysicalResist();

            FireDamage += Skills[i].GetFireDamage();
            FireDamageMultiple += Skills[i].GetFireDamageMultiple();
            FireResist += Skills[i].GetFireResist();

            IceDamage += Skills[i].GetIceDamage();
            IceDamageMultiple += Skills[i].GetIceDamageMultiple();
            IceResist += Skills[i].GetIceResist();

            PoisonDamage += Skills[i].GetPoisonDamage();
            PoisonDamageMultiple += Skills[i].GetPoisonDamageMultiple();
            PoisonResist += Skills[i].GetPoisonResist();

            DarkDamage += Skills[i].GetDarkDamage();
            DarkDamageMultiple += Skills[i].GetDarkDamageMultiple();
            DarkResist += Skills[i].GetDarkResist();

            ElectricDamage += Skills[i].GetElectricDamage();
            ElectricDamageMultiple += Skills[i].GetElectricDamageMultiple();
            ElectricResist += Skills[i].GetElectricResist();

            MaxHealth += Skills[i].GetMaxHealth();
            Regen(Skills[i].GetMaxHealth());

        }

    }

}
