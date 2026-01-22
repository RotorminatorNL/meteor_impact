using System.Collections;
using UnityEngine;

public class ExperienceHandler : MonoBehaviour
{
    [SerializeField] private MeteorHandler meteorHandler;
    [SerializeField] private GameObject blockView;

    private void Update()
    {
        if (!Input.anyKeyDown) return;

        int chosenExperience = 0;
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("All");
            chosenExperience = 1;
        }
        if (Input.GetKey(KeyCode.V))
        {
            Debug.Log("Visual");
            chosenExperience = 2;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Sound");
            chosenExperience = 3;
        }
        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("Tactile");
            chosenExperience = 4;
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("Experience 1: Visual + Auditory");
            chosenExperience = 5;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log("Experience 2: Visual + Tactile");
            chosenExperience = 6;
        }

        if (chosenExperience != 0) StartExperience(chosenExperience);
    }

    private void StartExperience(int chosenExperience)
    {
        StartCoroutine(meteorHandler.StartMeteor(chosenExperience));
        if (chosenExperience == 3 || chosenExperience == 4) blockView.SetActive(true);
        else StartCoroutine(DelayDisableBlockView());
    }

    private IEnumerator DelayDisableBlockView()
    {
        yield return new WaitForSeconds(0.1f);
        blockView.SetActive(false);
    }
}