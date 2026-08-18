using UnityEngine;

public class BombSkill : MonoBehaviour
{
    [SerializeField] private PlayerConfig config;
    [SerializeField] private Bomb bombPrefab;
    public float cooldownTime;



    private void Update()
    {
        if (cooldownTime > 0f)
            cooldownTime = cooldownTime - Time.deltaTime;

    }


    public void TryPlaceBomb()
    {
        if (cooldownTime > 0f) return;
        Bomb bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        cooldownTime = config.bombCooldown;

    }
    public float CooldownRatio
    {
        get { return cooldownTime / config.bombCooldown; }
    }
    public float CooldownRemaining
    {
        get { return cooldownTime; }
    }
}
