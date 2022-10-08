using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    //TODO: Needs rewriting for canvas

    [SerializeField] private Camera cameraComponent;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private Image fadeImg;
    private float fadeSpeed = 1;
    private float initialPosX, initialPosY;
    private float initialOrtographicSize;

    private void Start()
    {
        initialPosX = 320;
        initialPosY = 240;
        initialOrtographicSize = cameraComponent.orthographicSize;
    }

    public void ZoomIn(float posX, float posY, float ortographicSize)
    {
        StartCoroutine(SlowZoom());
        //cameraComponent.gameObject.GetComponent<RectTransform>().position = new Vector3(posX, posY, -10);
        //cameraComponent.orthographicSize = ortographicSize;
    }

    public void FadeZoomIn(float posX, float posY, float ortographicSize)
    {
        StartCoroutine(FadeIn(posX, posY, ortographicSize));
    }

    private IEnumerator SlowZoom()
    {
        // Zoom slowly, try to make zoom out and in same method.
        
        yield return new WaitForSeconds(0.1f);
    }

    public void ZoomOut()
    {
        StartCoroutine(SlowZoom());
        //cameraComponent.gameObject.GetComponent<RectTransform>().position = new Vector3(initialPosX, initialPosY, -10);
        //cameraComponent.orthographicSize = initialOrtographicSize;
    }

    public void FadeZoomOut()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn(float posX, float posY, float ortographicSize)
    {
        for (int i = 0; i <= 255; i++)
        {
            fadeImg.color = new Color32(0, 0, 0, (byte)i);
            yield return new WaitForSeconds(1 / fadeSpeed / 100);
        }

        // Needs to actually zoom over time
        cameraComponent.gameObject.GetComponent<RectTransform>().position = new Vector3(posX, posY, -10);
        cameraComponent.orthographicSize = ortographicSize;

        for (int i = 255; i >= 0; i--)
        {
            fadeImg.color = new Color32(0, 0, 0, (byte)i);
            yield return new WaitForSeconds(1 / fadeSpeed / 100);
        }
    }

    private IEnumerator FadeOut()
    {
        for (int i = 0; i <= 255; i++)
        {
            fadeImg.color = new Color32(0, 0, 0, (byte)i);
            yield return new WaitForSeconds(1 / fadeSpeed/100);
        }

        cameraComponent.gameObject.GetComponent<RectTransform>().position = new Vector3(initialPosX, initialPosY, -10);
        cameraComponent.orthographicSize = initialOrtographicSize;

        for (int i = 255; i >= 0; i--)
        {
            fadeImg.color = new Color32(0, 0, 0, (byte)i);
            yield return new WaitForSeconds(1 / fadeSpeed / 100);
        }
    }
}
