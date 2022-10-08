using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject introParent, mainParent, trainParent, convParent;

    public void ShowIntro()
    {
        introParent.SetActive(true);
        mainParent.SetActive(false);
        trainParent.SetActive(false);
        convParent.SetActive(false);
    }

    public void ShowMain()
    {
        mainParent.SetActive(true);
        introParent.SetActive(false);
        trainParent.SetActive(false);
        convParent.SetActive(false);
    }

    public void ShowTrain()
    {
        trainParent.SetActive(true);
        mainParent.SetActive(false);
        introParent.SetActive(false);
        convParent.SetActive(false);
    }

    public void ShowConv()
    {
        convParent.SetActive(true);
        mainParent.SetActive(false);
        introParent.SetActive(false);
        trainParent.SetActive(false);
    }
}
