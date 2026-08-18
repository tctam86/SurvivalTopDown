using UnityEngine;

public class PoisonEffect : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    private float dps;
    private float duration;
    private float tickTimer;

    public void ApplyPoison(float poisonDps, float poisonDuration)
    {
        duration = poisonDuration;
        dps = poisonDps;
        TickDamage();
        tickTimer = 1f;
    }

    void Update()
    {   
        if(duration <= 0) return;
        tickTimer -= Time.deltaTime;
        duration -= Time.deltaTime;
        if(tickTimer <= 0)
        {
            TickDamage();
            tickTimer = 1f;
        }
    }

    private void TickDamage()
    {
        playerHealth.TakeDamage(Mathf.RoundToInt(dps));
    }
}
