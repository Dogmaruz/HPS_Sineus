using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Transform target;

    [SerializeField] private Camera targetCamera;


    private float dist;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {

        characterMovement.TargetDirectionControl = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Mouse Y") * 100, Input.GetAxis("Vertical"));
      


        targetCamera.rotateControl = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        

        print(targetCamera.rotateControl);


            targetCamera.IsRotateTarget = true;     

    }

}
