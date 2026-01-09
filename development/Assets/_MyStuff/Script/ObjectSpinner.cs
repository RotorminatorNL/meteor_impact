using UnityEngine;

public class ObjectSpinner : MonoBehaviour
{
    [SerializeField, Range(0,1)] private float spinSpeed = 0.5f;
    [SerializeField] private float spinSpeedMultiplier = 300;

    private void Update()
    {
        float newSpinAngle = Time.deltaTime * spinSpeed * spinSpeedMultiplier;
        transform.Rotate(0, newSpinAngle, 0, Space.World);
    }
}