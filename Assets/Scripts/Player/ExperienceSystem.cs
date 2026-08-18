using UnityEngine;

public class ExperienceSystem : MonoBehaviour
{
    [SerializeField] private PlayerConfig config;
    [SerializeField] private PlayerHealth playerHealth;
    public int Level { get; private set; }
    private int exp;

    private const int ExpToLevel = 100;

    private void Awake()
    {
        Level = 1;
    }
    public void AddExp(int amount)
    {
        exp += amount;
        while(exp >= ExpToLevel)
        {
            exp -= ExpToLevel;
            LevelUp();
        }
        Debug.Log($"Current Level {Level}. Player received {exp}");

    }

    private void LevelUp()
    {
        Level++;
        playerHealth.IncreaseMaxHp(40);
        config.armour +=2;
        config.dmgMul += 0.1f;
        Debug.Log ("Level Up!");
    }
}
