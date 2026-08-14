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

}
