using UnityEngine;

public class RangedEnemy : EnemyBase
{
    [SerializeField] private PoisonBullet bulletPrefab;

    private float attackTimer;
    protected override void Update()
    {
        attackTimer -= Time.deltaTime;
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance > config.attackRange)
        {
            base.Update();
            return;
        }
        if (attackTimer <= 0) Shoot();
    }

    private void Shoot()
    {
        attackTimer = config.attackCooldown;

        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0f;

        transform.rotation = Quaternion.LookRotation(direction);
        PoisonBullet bullet = Instantiate(
            bulletPrefab,
        transform.position + transform.forward * 0.5f,
        Quaternion.identity
    );

        bullet.Setup(config, transform.forward);
    }
}