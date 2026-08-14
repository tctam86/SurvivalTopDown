using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float lifetime = 3f;
    private Vector3 direction;

    public void Setup(Vector3 dir, float dmg)
    {
        direction = dir;
        damage = Mathf.RoundToInt(dmg);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;

        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable target = other.GetComponent<IDamageable>();
        if(target != null)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        } 
    }
}
