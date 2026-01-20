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

        if (chosenExperience != 0) StartExperience(chosenExperience);
    }

    private void StartExperience(int chosenExperience)
    {
        StartCoroutine(meteorHandler.StartMeteor(chosenExperience));
        if (chosenExperience == 1 || chosenExperience == 2) blockView.SetActive(false);
        else if (chosenExperience == 3 || chosenExperience == 4) blockView.SetActive(true);
    }
}