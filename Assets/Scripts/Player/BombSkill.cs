using UnityEngine;
using UnityEngine.InputSystem;
public class BombSkill : MonoBehaviour
{
    [SerializeField] private PlayerConfig config;
    [SerializeField] private Bomb bombPrefab;
    public float cooldownTime;



    private void Update()
    {
        if (cooldownTime > 0f)
            cooldownTime = cooldownTime - Time.deltaTime;

        if (Keyboard.current != null && Keyboard.current.kKey.wasPressedThisFrame)
            TryPlaceBomb();

    }


    public void TryPlaceBomb()
    {
        if (cooldownTime > 0f) return;
        Bomb bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        cooldownTime = config.bombCooldown;

    }
}
