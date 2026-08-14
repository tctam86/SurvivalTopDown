
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingSkill : MonoBehaviour
{
    [SerializeField] private PlayerConfig config;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform firePoint;
    private int charge;
    private float chargeTime;
    private float lastFireTime;


    void Awake()
    {
        charge = config.maxCharge;
    }

    void Update()
    {
        ChargeRegen();

        if (Keyboard.current != null && Keyboard.current.jKey.wasPressedThisFrame)
            TryFire();
    }

    private void ChargeRegen()
    {
        if (charge >= config.maxCharge) return;

        chargeTime += Time.deltaTime;

        if (chargeTime >= config.chargeRegen)
        {
            charge++;
            chargeTime = 0f;
            Debug.Log($"Charge regenerated. Current charge: {charge}/{config.maxCharge}");
        }
    }

    public void TryFire()
    {
        if (Time.time - lastFireTime < config.fireInterval || charge <= 0) return;
        Fire();

    }

    private void Fire()
    {
        lastFireTime = Time.time;
        charge--;
        Debug.Log($"Fired! Current charge: {charge}/{config.maxCharge}");

        int damage = Mathf.RoundToInt(config.bulletDamage * (1f + config.dmgMul));

        for (int i = -1; i <= 1; i++)
        {
            float angle = i * config.spreadAngle;
            Vector3 dir = Quaternion.Euler(0f, angle, 0f) * transform.forward;

            Bullet bullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.identity
            );

            bullet.Setup(dir, damage);
        }
    }
}
