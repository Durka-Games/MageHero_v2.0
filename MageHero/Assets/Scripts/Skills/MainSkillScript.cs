using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSkillScript
{
    //health
    protected float MaxHealth;

    public float GetMaxHealth() => MaxHealth;

    //damage
    protected float PhysicalDamage;
    protected float PhysicalDamageMultiple;

    protected float FireDamage;
    protected float FireDamageMultiple;

    protected float IceDamage;
    protected float IceDamageMultiple;

    protected float PoisonDamage;
    protected float PoisonDamageMultiple;

    protected float DarkDamage;
    protected float DarkDamageMultiple;

    protected float ElectricDamage;
    protected float ElectricDamageMultiple;

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

    //atack
    protected List<float> Angles = new List<float>();
    public List<float> GetAngles() => Angles;

    protected float AtackSpeed;
    public float GetAtackSpeed() => AtackSpeed;

    //resistance
    protected float PhysicalResist;
    protected float FireResist;
    protected float IceResist;
    protected float PoisonResist;
    protected float DarkResist;
    protected float ElectricResist;

    public float GetPhysicalResist() => PhysicalResist;
    public float GetFireResist() => FireResist;
    public float GetIceResist() => IceResist;
    public float GetPoisonResist() => PoisonResist;
    public float GetDarkResist() => DarkResist;
    public float GetElectricResist() => ElectricResist;

    //other
    protected float Speed;
    public float GetSpeed() => Speed;

}
