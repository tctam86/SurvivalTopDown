using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected EnemyConfig config;
    [SerializeField] protected Transform player;
    protected virtual void Awake()
    {
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
                player = playerObject.transform;
        }

    }

    protected virtual void Update()
    {
        Chase();
    }

    private void Chase()
    {
        Vector3 dir = player.position - transform.position;
        dir.y = 0f;

        if (dir.magnitude > config.attackRange) 
        {
            transform.position += dir.normalized * config.moveSpeed * Time.deltaTime;
        }
    }
}
