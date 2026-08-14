using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private PlayerHealth playerHealth;

    private Camera playerCamera;

    void Awake()
    {
     playerCamera = Camera.main;
    } 
    void Update()
    {
        float ratio = (float)playerHealth.CurrentHp / playerHealth.MaxHp;
        fillImage.fillAmount = ratio;

        transform.rotation = playerCamera.transform.rotation;
    }
}
