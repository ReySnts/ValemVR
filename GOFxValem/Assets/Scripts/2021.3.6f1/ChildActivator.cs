using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ChildActivator : MonoBehaviour
{
    [SerializeField] private GameObject rayTeleport;

    [SerializeField] private GameObject rayGrab;

    [SerializeField] private InputActionProperty activateProperty;

    [SerializeField] private InputActionProperty selectProperty;

    [SerializeField] private XRDirectInteractor xRDirectInteractor;

    private void Update()
    {
        rayTeleport.SetActive(activateProperty.action.ReadValue<float>() > 0.1f && selectProperty.action.ReadValue<float>() == 0f);
        rayGrab.SetActive(xRDirectInteractor.interactablesSelected.Count == 0);
    }
}