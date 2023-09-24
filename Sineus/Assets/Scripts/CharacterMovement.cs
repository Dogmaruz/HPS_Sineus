using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speedFly;

    private CharacterController characterController;
    public Vector3 TargetDirectionControl;
    public Vector3 DirectionControl;
    private Vector3 movementDirections;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (ÑharacterizationEcomorf.Instance.SpeedChar > 5)
            speedFly = speedFly  + (ÑharacterizationEcomorf.Instance.SpeedChar - 5) + 4;

    }

    private void FixedUpdate()
    {                
        Move();
    }

    private void Move()
    {
        DirectionControl = Vector3.MoveTowards(DirectionControl, TargetDirectionControl, Time.fixedDeltaTime);



        movementDirections = DirectionControl * speedFly * Time.fixedDeltaTime;

        movementDirections = transform.TransformDirection(movementDirections);
       // movementDirections += Physics.gravity * Time.deltaTime;
        characterController.Move(movementDirections );
    }
}