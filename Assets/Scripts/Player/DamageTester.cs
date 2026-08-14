using UnityEngine;
using UnityEngine.InputSystem;

public class DamageTester : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    


    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.hKey.wasPressedThisFrame)
        {
            playerHealth.TakeDamage(50);
            Debug.Log("Bấm H: gây 50 sát thương");
        }
    }
}
