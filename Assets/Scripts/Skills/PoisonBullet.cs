using UnityEngine;

public class PoisonBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private EnemyConfig config;

    private Vector3 direction;
    private float traveled;

    public void Setup(EnemyConfig cfg, Vector3 dir)
    {
        config = cfg;
        direction = dir;
    }

    private void Update()
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;
        traveled += speed * Time.deltaTime;
        if (traveled >= maxDistance)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        PoisonEffect poison = other.GetComponent<PoisonEffect>();
        if(poison != null)
        {
            poison.ApplyPoison(config.poisonDps, config.poisonDuration);
            Destroy(gameObject);
        
        }
        
    }

}