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
        ShowIntro();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            ShowMain();
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

    private IEnumerator WaitForConv(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        cameraZoom.ZoomOut();

        convParent.SetActive(true);
        mainParent.SetActive(false);
        introParent.SetActive(false);
        trainParent.SetActive(false);
    }

    public void ShowConv()
    {
        /*
        cameraZoom.FadeZoomIn(354, -134, 80);

        StartCoroutine(WaitForConv(2.5f));
        */

        convParent.SetActive(true);
        mainParent.SetActive(false);
        introParent.SetActive(false);
        trainParent.SetActive(false);
    }
}
