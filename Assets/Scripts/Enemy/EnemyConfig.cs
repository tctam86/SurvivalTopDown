using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Scriptable Objects/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [Header("Base Stats")]
    public int maxHp = 100;
    public float moveSpeed = 3f;

    [Header("Attack")]
    public int attackDamage;
    public float attackRange;
    public float attackAngle;
    public int attackCooldown;

    [Header("Range")]
    public float bulletSpeed;
    public float poisonDps;
    public float poisonDuration;
    public int poisonTickCount;


}
