using UnityEngine;
using UnityEngine.UI;



public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private EnemyHealth enemyHealth;
    private Camera enemyCamera;

    private void Awake()
    {
        enemyCamera = Camera.main;
    }

    private void Update()
    {
        float ratio = (float)enemyHealth.CurrentHp / enemyHealth.MaxHp;
        fillImage.fillAmount = ratio;
        transform.rotation = enemyCamera.transform.rotation;

    }
}
