using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    private float attackTimer;
    protected override void Update()
    {
        attackTimer -= Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > config.attackRange)
        {
            base.Update();
            return;
        }

        if (attackTimer <= 0f)
        {
            Attack();
        }
    }
    private void Attack()
    {
        Vector3 direction = player.position - transform.position;

        direction.y = 0f;

        if (direction.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
        float angle = Vector3.Angle(transform.forward, direction);

        if (angle <= config.attackAngle / 2f)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(config.attackDamage);
                attackTimer = config.attackCooldown;
            }
        }
    }
}
