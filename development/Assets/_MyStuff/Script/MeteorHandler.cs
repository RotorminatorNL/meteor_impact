using System.Collections;
using UnityEngine;

public class MeteorHandler : MonoBehaviour
{
    [Header("Visual")]
    [SerializeField] private Animator meteorImpactController;
    [SerializeField] private Animator meteorSpinningController;
    [Header("Sound")]
    [SerializeField] private AudioSource meteorAudio;
    [SerializeField] private AudioClip meteorIncoming;
    [SerializeField] private AudioClip meteorHit;
    [SerializeField, Range(0,1)] private float spatialBlend = 1;

    private bool useSound = false;

    private void Update()
    {
        meteorAudio.spatialBlend = spatialBlend;
    }

    public IEnumerator StartMeteor(int chosenExperience)
    {
        useSound = false;
        meteorImpactController.SetBool("Active", false);
        meteorSpinningController.SetBool("Active", false);
        meteorAudio.Stop();
        yield return new WaitForSeconds(0.05f);
        meteorImpactController.SetBool("Active", true);
        meteorSpinningController.SetBool("Active", true);
        if (chosenExperience == 1 || chosenExperience == 3) UseMeteorSound();
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