using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject introParent, mainParent, trainParent, convParent;
    private CameraZoom cameraZoom;

    private void Start()
    {
        cameraZoom = Camera.main.gameObject.GetComponent<CameraZoom>();
    }

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

    private IEnumerator WaitForConv(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        cameraZoom.FadeZoomOut();

        convParent.SetActive(true);
        mainParent.SetActive(false);
        introParent.SetActive(false);
        trainParent.SetActive(false);
    }

    public void ShowConv()
    {
        Debug.Log("Press");
        cameraZoom.FadeZoomIn(354, -134, 80);

        StartCoroutine(WaitForConv(5));
    }
}
