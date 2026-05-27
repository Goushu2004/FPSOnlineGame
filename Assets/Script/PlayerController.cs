using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
public class PlayerController : MonoBehaviour
{
    private Vector2 playerInput;
    private float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = transform.right * playerInput.x + transform.forward * playerInput.y;
    }
    public void OnMove(InputValue value) 
    {
        if (value != null) 
        {
            playerInput = value.Get<Vector2>();
        }
    }
}
