using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class MeteorHandler : MonoBehaviour
{
    [Header("Visual")]
    [SerializeField] private Animator meteorImpactController;
    [SerializeField] private Animator meteorSpinningController;
    [SerializeField] private GameObject deathSpotLight;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private bool deathActive = false;
    [Header("Sound")]
    [SerializeField] private AudioSource meteorAudio;
    [SerializeField] private AudioClip meteorIncoming;
    [SerializeField] private AudioClip meteorHit;
    [SerializeField, Range(0, 1)] private float spatialBlend = 1;
    [Header("Tactile")]
    [SerializeField] private HapticImpulsePlayer leftController;
    [SerializeField] private HapticImpulsePlayer rightController;
    [SerializeField, Range(0, 1)] private float hapticAmplitude;
    [SerializeField, Range(0, 1)] private float hapticRndRange;

    private int currentExperience = 0;
    private bool useSound = false;
    private bool useTactile = false;

    private void Update()
    {
        if (useSound) meteorAudio.spatialBlend = spatialBlend;
        if (useTactile)
        {
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

        if (deathActive && currentExperience != 3 && currentExperience != 4)
        {
            deathSpotLight.SetActive(true);
            deathScreen.SetActive(true);
        }
        else
        {
            deathSpotLight.SetActive(false);
            deathScreen.SetActive(false);
        }
    }
    public IEnumerator StartMeteor(int chosenExperience)
    {
        currentExperience = chosenExperience;
        useSound = false;
        useTactile = false;
        meteorImpactController.SetBool("Active", false);
        meteorSpinningController.SetBool("Active", false);
        meteorAudio.Stop();
        yield return new WaitForSeconds(0.05f);
        meteorImpactController.SetBool("Active", true);
        meteorSpinningController.SetBool("Active", true);
        if (chosenExperience == 1 || chosenExperience == 3 || chosenExperience == 5) UseMeteorSound();
        if (chosenExperience == 1 || chosenExperience == 4 || chosenExperience == 6) useTactile = true;
    }

    public void MeteorHit()
    {
        meteorSpinningController.SetBool("Active", false);
    }

    private void UseMeteorSound()
    {
        useSound = true;
        meteorAudio.resource = meteorIncoming;
        meteorAudio.loop = true;
        meteorAudio.Play();
    }

    public void PlayMeteorHit()
    {
        if (!useSound) return;
        meteorAudio.Stop();
        meteorAudio.resource = meteorHit;
        meteorAudio.loop = false;
        meteorAudio.Play();
    }
}