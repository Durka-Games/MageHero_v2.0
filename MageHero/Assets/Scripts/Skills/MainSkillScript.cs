using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSkillScript
{
    //health
    private float MaxHealth;

    public float GetMaxHealth() => MaxHealth;

    //damage
    private float PhysicalDamage;
    private float PhysicalDamageMultiple;

    private float FireDamage;
    private float FireDamageMultiple;

    private float IceDamage;
    private float IceDamageMultiple;

    private float PoisonDamage;
    private float PoisonDamageMultiple;

    private float DarkDamage;
    private float DarkDamageMultiple;

    private float ElectricDamage;
    private float ElectricDamageMultiple;

    public float GetPhysicalDamage() => PhysicalDamage;
    public float GetFireDamage() => FireDamage;
    public float GetIceDamage() => IceDamage;
    public float GetPoisonDamage() => PoisonDamage;
    public float GetDarkDamage() => DarkDamage;
    public float GetElectricDamage() => ElectricDamage;

    public float GetPhysicalDamageMultiple() => PhysicalDamageMultiple;
    public float GetFireDamageMultiple() => FireDamageMultiple;
    public float GetIceDamageMultiple() => IceDamageMultiple;
    public float GetPoisonDamageMultiple() => PoisonDamageMultiple;
    public float GetDarkDamageMultiple() => DarkDamageMultiple;
    public float GetElectricDamageMultiple() => ElectricDamageMultiple;

    //resistance
    private float PhysicalResist;
    private float FireResist;
    private float IceResist;
    private float PoisonResist;
    private float DarkResist;
    private float ElectricResist;

    public float GetPhysicalResist() => PhysicalResist;
    public float GetFireResist() => FireResist;
    public float GetIceResist() => IceResist;
    public float GetPoisonResist() => PoisonResist;
    public float GetDarkResist() => DarkResist;
    public float GetElectricResist() => ElectricResist;

}
