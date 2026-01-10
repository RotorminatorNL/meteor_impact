using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class HapticHandler : MonoBehaviour
{
    [SerializeField] private float maxDistance = 0.5f;
    [SerializeField] private Transform hapticSender;
    [SerializeField] private HapticImpulsePlayer leftController;
    [SerializeField] private HapticImpulsePlayer rightController;

    void Update()
    {
        ControllerHaptic(leftController, Vector3.Distance(leftController.transform.position, hapticSender.position));
        ControllerHaptic(rightController, Vector3.Distance(rightController.transform.position, hapticSender.position));
    }

    private void ControllerHaptic(HapticImpulsePlayer controller, float distance)
    {
        if (distance < maxDistance)
        {
            controller.SendHapticImpulse(Mathf.InverseLerp(maxDistance, 0, distance), 0, 300);
            return;
        }
        controller.SendHapticImpulse(0, 0, 0);
    }
}