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

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    private void Update()
    {                
        Move();
    }

    private void Move()
    {
        DirectionControl = Vector3.MoveTowards(DirectionControl, TargetDirectionControl, Time.deltaTime * speedFly);



        movementDirections = DirectionControl * speedFly;

        movementDirections = transform.TransformDirection(movementDirections);
        movementDirections += Physics.gravity * Time.deltaTime;
        characterController.Move(movementDirections * Time.deltaTime);
    }



}