using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speedFly;
    [SerializeField] private float upSpeed;


    private CharacterController characterController;
    public Vector3 TargetDirectionControl;
    public Vector3 DirectionControl;
    private Vector3 movementDirections;
     Rigidbody rb;
    


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      
            
        Move();
    }

    private void Move()
    {
        DirectionControl = Vector3.MoveTowards(DirectionControl, TargetDirectionControl, Time.deltaTime * speedFly);



        movementDirections = DirectionControl * speedFly;


        if (Input.GetKeyDown(KeyCode.E))
        {
            movementDirections.y = upSpeed;
          
        }
        movementDirections = transform.TransformDirection(movementDirections);

        characterController.Move(movementDirections * Time.deltaTime);
    }



}