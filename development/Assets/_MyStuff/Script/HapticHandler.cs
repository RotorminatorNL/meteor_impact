using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class HapticHandler : MonoBehaviour
{
    [SerializeField] private HapticImpulsePlayer leftController;
    [SerializeField] private HapticImpulsePlayer rightController;
    [SerializeField] private float hapticRndRange = 0.3f;
    [SerializeField, Range(0, 1)] private float hapticAmplitude;

    private bool hapticOn = false;

    private void Update()
    {
        if (!hapticOn) return;

        float minRndRange = hapticAmplitude - hapticRndRange;
        float maxRndRange = hapticAmplitude + hapticRndRange;

        float rndImpulseLeft = Random.Range(minRndRange, maxRndRange);
        if (rndImpulseLeft < 0) rndImpulseLeft = 0;
        if (rndImpulseLeft > 1) rndImpulseLeft = 1;
        float rndImpulseRight = Random.Range(minRndRange, maxRndRange);
        if (rndImpulseRight < 0) rndImpulseRight = 0;
        if (rndImpulseRight > 1) rndImpulseRight = 1;
        leftController.SendHapticImpulse(rndImpulseLeft, 0);
        rightController.SendHapticImpulse(rndImpulseRight, 0);
    }

    public void StartHaptic()
    {
        hapticOn = true;
    }

    public void ChangeHapticImpulseMaxRndRange(float amount)
    {
        hapticRndRange = amount;
    }

    public void StopHaptic()
    {
        hapticOn = false;
        leftController.SendHapticImpulse(0, 0);
        rightController.SendHapticImpulse(0, 0);
    }
}