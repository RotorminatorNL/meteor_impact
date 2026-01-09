using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class HapticHandler : MonoBehaviour
{
    [SerializeField] private Transform hapticSender;
    [SerializeField] private HapticImpulsePlayer leftController;
    [SerializeField] private HapticImpulsePlayer rightController;

    void Update()
    {
        float leftDistance = Vector3.Distance(leftController.transform.position, hapticSender.position);
        float rightDistance = Vector3.Distance(rightController.transform.position, hapticSender.position);
        Debug.Log($"Left distance: {leftDistance} | Right distance: {rightDistance}");
    }
}