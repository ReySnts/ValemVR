using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    [SerializeField] private InputDeviceCharacteristics desiredCharacteristics;

    [SerializeField] private GameObject controllerPrefab;

    [SerializeField] private GameObject handModelPrefab;

    private GameObject controllerGameObject;

    private GameObject handGameObject;

    private Animator handAnimator;

    private InputDevice targetInputDevice;

    private readonly bool controllerIsAllowedToShow = false;

    private void Start() => ValidateInputDevice();

    private void ValidateInputDevice()
    {
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, inputDevices);
        if (inputDevices.Count > 0)
        {
            targetInputDevice = inputDevices[0];
            controllerGameObject = Instantiate(original: controllerPrefab, parent: transform);
            handGameObject = Instantiate(original: handModelPrefab, parent: transform);
            handAnimator = handGameObject.GetComponent<Animator>();
        }
    }

    private void Update()
    {
        if (!targetInputDevice.isValid) ValidateInputDevice();
        else
        {
            controllerGameObject.SetActive(controllerIsAllowedToShow);
            handGameObject.SetActive(!controllerIsAllowedToShow);
            if (targetInputDevice.TryGetFeatureValue(usage: CommonUsages.grip, value: out var gripValue))
                handAnimator.SetFloat(AnimatorParameterName.GRIP, gripValue);
            if (targetInputDevice.TryGetFeatureValue(usage: CommonUsages.trigger, value: out var triggerValue))
                handAnimator.SetFloat(AnimatorParameterName.TRIGGER, triggerValue);
        }
    }
}