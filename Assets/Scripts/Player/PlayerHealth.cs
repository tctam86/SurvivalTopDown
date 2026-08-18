using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerConfig config;


    private int currentHp;
    private int maxHp;
    private int armor;
    private float dmgMultiplier;

    private void Awake()
    {
        config.maxHp = 500;
        config.armour = 0;
        config.dmgMul = 0f;

        currentHp = config.maxHp;
    }

    public void TakeDamage(int rawDamage)
    {
        int dmg = Mathf.Max(0, rawDamage - config.armour);
        currentHp = Math.Max(0, currentHp - dmg);
    }

    public void IncreaseMaxHp(int amount)
    {
        config.maxHp += amount;
        currentHp += amount;
    }

    public int CurrentHp
    {
        get { return currentHp; }
    }
    public int MaxHp
    {
        get { return config.maxHp; }
    }
}
