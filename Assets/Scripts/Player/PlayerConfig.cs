using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Scriptable Objects/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [Header("Health")]
    public int maxHp = 500;

    [Header("Movement")]
    public float moveSpeed = 2f;
    public float rotateSpeed = 180f;

    [Header("Combat")]
    public int armour = 0;
    public float dmgMul = 0;

    [Header("Shooting")]
    public int bulletDamage = 10;
    public int maxCharge = 3;
    public float chargeRegen = 3f;
    public float fireInterval = 0.5f;
    public float spreadAngle = 15f;
    public float bulletSpeed = 20f;


    [Header("Bomb")]
    public int bombDamage = 50;
    public float bombCooldown = 12f;
    public float bombRadius = 5f;
    public float bombDelay = 2f;

    [Header("Dash")]
    public float dashDistance = 3f;
    public float dashDuration = 0.3f;
    public int dashDamage = 15;
    public float dashRadius = 3f;
    public float dashCooldown = 6f;
}
