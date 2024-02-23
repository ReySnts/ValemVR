using UnityEngine;
using UnityEngine.InputSystem;

public class ChildActivator : MonoBehaviour
{
    [SerializeField] GameObject rayInteractor;

    [SerializeField] InputActionProperty activateProperty;

    [SerializeField] InputActionProperty selectProperty;

    private void Update() => rayInteractor.SetActive(activateProperty.action.ReadValue<bool>() && selectProperty.action.ReadValue<bool>());
}