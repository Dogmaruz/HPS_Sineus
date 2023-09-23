using UnityEngine;

public class CharacterAnimationState : MonoBehaviour
{
    private const float INPUT_CONTROL_LERP = 10f;
    [SerializeField] private CharacterController targetCharacterController;
    [SerializeField] private CharacterMovement characterMovement;


    [SerializeField] private Animator targetAnimator;



    private Vector3 inputControl;
    private bool isPickup;

    private void LateUpdate()
    {
        Vector3 movementSpeed = transform.InverseTransformDirection(targetCharacterController.velocity);
        inputControl = Vector3.MoveTowards(inputControl, characterMovement.TargetDirectionControl, Time.deltaTime * INPUT_CONTROL_LERP);
        targetAnimator.SetFloat("NormolizeMovementX", inputControl.x);
        targetAnimator.SetFloat("NormolizeMovementZ", inputControl.z);
        targetAnimator.SetBool("isPickup", isPickup);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Trash trash))
        {
            isPickup = true;
        }
        else
            isPickup = false;
    }    
}
