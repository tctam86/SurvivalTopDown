using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerConfig config;

    private int currentHp;

    private void Awake()
    {
        currentHp = config.maxHp;
        Debug.Log($"Current HP: {currentHp}");
    }

    public void TakeDamage(int rawDamage)
    {
        int dmg = Mathf.Max(0, rawDamage - config.armour);
        currentHp = Math.Max(0, currentHp - dmg);
        Debug.Log($"Player received: {dmg} attack damage, Remain HP {currentHp} ");

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
