using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction moveAction;
    [SerializeField] private Movement Movement_;
    private bool isCrouching;
   

    private CharacterController controller;

    [SerializeField]
    float playerSpeed = 5f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        Vector2 direction = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(direction.x, 0, direction.y) * playerSpeed * Time.deltaTime;
        gameObject.GetComponent<CharacterController>().Move(movement);

        //Sprinting
        var targetSpeed = Movement_.isSprinting ? Movement_.speed * Movement_.multipler : Movement_.speed;
        Movement_.currentSpeed = Mathf.MoveTowards(Movement_.currentSpeed, targetSpeed, Movement_.acceleration * Time.deltaTime);
        controller.Move(direction * Movement_.currentSpeed * Time.deltaTime);

        
    }

   public void Sprint(InputAction.CallbackContext context)
    {
        Movement_.isSprinting = context.started || context.performed;
    }
     
    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.localScale = new Vector3(1f, 0.5f);
        }
        else
        { transform.localScale = new Vector3(1f, 1f); }
        
    }
    
    
    [System.Serializable]
    public struct Movement
    {
        public float speed;
        public float multipler;
        public float acceleration;
        [HideInInspector]public bool isSprinting;
        [HideInInspector] public float currentSpeed;
        [HideInInspector] public bool isCrouching;
    }

   
    
}
