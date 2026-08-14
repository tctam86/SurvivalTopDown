using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerConfig config;
    private CharacterController controller;
    private Vector2 moveInput;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void SetMoveInput(Vector2 input)
    {
        moveInput = input;
    }

    void Update()
    {
        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y);
        if (direction.magnitude > 0.1f)
        {
            RotateToward(direction.normalized);
            controller.Move(direction.normalized * config.moveSpeed * Time.deltaTime);
        }
    }

    private void RotateToward(Vector3 targetDir)
    {
        float angleTarget = Vector3.SignedAngle(transform.forward, targetDir, Vector3.up);
        float maxTurn = config.rotateSpeed * Time.deltaTime;
        float turn = Mathf.Clamp(angleTarget, -maxTurn, maxTurn);
        transform.Rotate(Vector3.up,turn);
    }
}
