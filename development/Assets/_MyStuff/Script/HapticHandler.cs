using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class HapticHandler : MonoBehaviour
{
    [SerializeField] private Transform hapticSender;
    [SerializeField] private HapticImpulsePlayer leftController;
    [SerializeField] private HapticImpulsePlayer rightController;

    private float currentAmplify = 0.2f;
    private float currentDuration = 0.8f;

    private void Start()
    {
        leftController.SendHapticImpulse(currentAmplify, currentDuration);
        rightController.SendHapticImpulse(currentAmplify, currentDuration);
    }
}