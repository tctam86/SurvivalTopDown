using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyConfig config;

    private int currentHp;
    public int CurrentHp
    {
        get { return currentHp; }
    }
    public int MaxHp
    {
        get { return config.maxHp; }
    }
    private void Awake()
    {
        currentHp = config.maxHp;
    }
    public void TakeDamage(int rawDamage)
    {
        currentHp = Mathf.Max(0, currentHp - rawDamage);

        if (currentHp <= 0)
        {
            ExperienceSystem exp = FindFirstObjectByType<ExperienceSystem>();
            if (exp != null) exp.AddExp(30);
            Destroy(gameObject);
        }
    }
}
