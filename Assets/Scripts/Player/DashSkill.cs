using UnityEngine;

public class DashSkill : MonoBehaviour
{
    [SerializeField] private PlayerConfig config;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private CharacterController controller;

    private float cooldownTime;
    private float dashTimer;
    private Vector3 dashDirection;

    private bool isDashing;

    private void Update()
    {
        if (cooldownTime > 0f) cooldownTime -= Time.deltaTime;
        if (isDashing)
        {
            DashMovement();
            return;
        }

    }

    public void TryDash()
    {
        if (cooldownTime > 0 || isDashing) return;

        isDashing = true;
        dashTimer = config.dashDuration;
        dashDirection = transform.forward;
        movement.enabled = false;
        cooldownTime = config.dashCooldown;
    }

    private void DashMovement()
    {
        dashTimer -= Time.deltaTime;

        float speed = config.dashDistance / config.dashDuration;
        controller.Move(dashDirection * speed * Time.deltaTime);

        if (dashTimer <= 0f)
        {
            Explode();
            movement.enabled = true;
            isDashing = false;
            Debug.Log("Dash ended, explosion!");


        }

    }
    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, config.dashRadius);
        foreach (Collider hit in hits)
        {
            if (hit.gameObject == gameObject) continue;
            IDamageable target = hit.GetComponent<IDamageable>();
            if (target != null)
                target.TakeDamage(config.dashDamage);
        }
    }
    public float CooldownRatio
    {
        get { return cooldownTime / config.dashCooldown; }
    }
    public float CooldownRemaining
    {
        get { return cooldownTime; }
    }
}
