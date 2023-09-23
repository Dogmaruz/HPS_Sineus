using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Transform target;
    [SerializeField] private float verticalSpeed;

    [SerializeField] private CameraController targetCamera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        characterMovement.TargetDirectionControl = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        targetCamera.rotateControl = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        targetCamera.ScrollDistanceCamera(Input.GetAxis("Mouse ScrollWheel"));

        if (characterMovement.TargetDirectionControl != Vector3.zero )
        {
            targetCamera.IsRotateTarget = true;
        }
        else
            targetCamera.IsRotateTarget = false;
 
    }
}
