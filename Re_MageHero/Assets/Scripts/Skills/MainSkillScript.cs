using System;
using System.Collections.Generic;
using UnityEngine;

public class MainSkillScript : MonoBehaviour
{

    public MainSkillScript() 
    {

        MaxHealth = 0;

        PhysicalDamage = 0;
        PhysicalDamageMultiple = 0;

        FireDamage = 0;
        FireDamageMultiple = 0;

        IceDamage = 0;
        IceDamageMultiple = 0;

        PoisonDamage = 0;
        PoisonDamageMultiple = 0;

        DarkDamage = 0;
        DarkDamageMultiple = 0;

        ElectricDamage = 0;
        ElectricDamageMultiple = 0;

        AtackSpeed = 0;

        PhysicalResist = 0;
        FireResist = 0;
        IceResist = 0;
        PoisonResist = 0;
        DarkResist = 0;
        ElectricResist = 0;

        Speed = 0;

}

    public void SetMaxHealth(float value) => MaxHealth = value;

    public void SetPhysicalDamage(float value) => PhysicalDamage = value;
    public void SetPhysicalDamageMultiple(float value) => PhysicalDamageMultiple = value;
    public void SetFireDamage(float value) => FireDamage = value;
    public void SetFireDamageMultiple(float value) => FireDamageMultiple = value;
    public void SetIceDamage(float value) => IceDamage = value;
    public void SetIceDamageMultiple(float value) => IceDamageMultiple = value;
    public void SetPoisonDamage(float value) => PoisonDamage = value;
    public void SetPoisonDamageMultiple(float value) => PoisonDamageMultiple = value;
    public void SetDarkDamage(float value) => DarkDamage = value;
    public void SetDarkDamageMultiple(float value) => DarkDamageMultiple = value;
    public void SetElectricDamage(float value) => ElectricDamage = value;
    public void SetElectricDamageMultiple(float value) => ElectricDamageMultiple = value;
    public void SetAtackSpeed(float value) => AtackSpeed = value;
    public void SetPhysicalResist(float value) => PhysicalResist = value;
    public void SetFireResist(float value) => FireResist = value;
    public void SetIceResist(float value) => IceResist = value;
    public void SetPoisonResist(float value) => PoisonResist = value;
    public void SetDarkResist(float value) => DarkResist = value;
    public void SetElectricResist(float value) => ElectricResist = value;
    public void SetSpeed(float value) => Speed = value;

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
