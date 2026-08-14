using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 15f, -13f);
    [SerializeField] private float followSpeed = 8f;

    private void LateUpdate()
    {
        Vector3 expectedPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, expectedPos, followSpeed * Time.deltaTime);
    }
}
