using UnityEngine;
using UnityEngine.InputSystem;

public class OnInputHandAnimator : MonoBehaviour
{
    [SerializeField] private InputActionProperty activateValueProperty;

    [SerializeField] private InputActionProperty selectValueProperty;

    [SerializeField] private Animator animator;

    private void Update()
    {
        var gripValue = selectValueProperty.action.ReadValue<float>();
        var triggerValue = activateValueProperty.action.ReadValue<float>();
        animator.SetFloat(AnimatorParameterName.GRIP, gripValue);
        animator.SetFloat(AnimatorParameterName.TRIGGER, triggerValue);
    }
}