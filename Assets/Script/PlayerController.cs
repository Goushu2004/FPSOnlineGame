using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    Vector3 velocity;
    private float moveSpeed = 2f;
    private Animator playerAnimator;
    public GameObject playerPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimatorParameters();
    }
    private void FixedUpdate()
    {
        Vector3 moveDirection = (playerPosition.transform.forward * verticalInput + playerPosition.transform.right * horizontalInput).normalized;
        velocity = moveDirection * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }
    public void OnMove(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            horizontalInput = input.x;
            verticalInput = input.y;
        }
        else if (context.canceled)
        {
            horizontalInput = 0f;
            verticalInput = 0f;
        }
    }
    public void OnCourch(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            playerAnimator.SetBool("IsCourching", true);
        }
        else if (context.canceled)
        {
            playerAnimator.SetBool("IsCourching", false);
        }
    }
    public void SetAnimatorParameters() 
    {
        playerAnimator.SetFloat("VelocityX", horizontalInput);
        playerAnimator.SetFloat("VelocityZ", verticalInput);
    }
}
