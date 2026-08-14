using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float delay = 2f;
    [SerializeField] private float radius = 5f;
    [SerializeField] private int damage = 50;

    private float countdown;

    private void Awake()
    {
        countdown = delay;
    }


    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0) Explode();

    }
    public void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in hits)
        {
            IDamageable target = hit.GetComponent<IDamageable>();
            if (target != null)
                target.TakeDamage(damage);
        }
        Debug.Log("Bomb exploded!");
        Destroy(gameObject);

    }


}
