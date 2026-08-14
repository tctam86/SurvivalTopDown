using UnityEngine;

public class TestTarget : MonoBehaviour, IDamageable
{
    public void TakeDamage(int baseDamage)
    {
        Debug.Log($"Target hit for {baseDamage} damage!");
    }
}
