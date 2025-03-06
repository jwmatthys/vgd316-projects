using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TPCC : MonoBehaviour
{
    public float walkingSpeed = 2f;
    public float sprintSpeed = 8f;
    public float rotationSpeed = 60f;
    public float acceleration = 5f;
    private bool isSprinting;
    private float rotation;
    private CharacterController characterController;
    private Animator anim;
    private float movementSpeed;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Rotate with A-D
        float turnInput = Input.GetAxis("Horizontal");
        float turn = turnInput * rotationSpeed;
        transform.Rotate(0, turn * Time.deltaTime, 0);

        // Move with W-S
        // Sprint with Left Shift
        float pace = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkingSpeed;
        float speed = pace * Input.GetAxis("Vertical");
        if (speed < -walkingSpeed) speed = -walkingSpeed;
        movementSpeed = Mathf.Lerp(movementSpeed, speed, Time.deltaTime * acceleration);
        Vector3 movement = movementSpeed * transform.forward;
        characterController.SimpleMove(movement);
        anim.SetFloat("Speed", movementSpeed);
    }
}