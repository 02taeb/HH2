using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    //TODO: Needs rewriting for canvas

    [SerializeField] private Camera cameraComponent;
    [SerializeField] private float zoomSpeed;
    [Tooltip("Ortographic size camera should change to if camera is in perspective mode")]
    [SerializeField] private float newOrtographicSize;
    private float zoomFactor = 100f;
    private float initialPosX, initialPosY;
    private float initialOrtographicSize;

    private void Start()
    {
        initialPosX = cameraComponent.gameObject.GetComponent<RectTransform>().rect.x;
        initialPosY = cameraComponent.gameObject.GetComponent<RectTransform>().rect.y;
        initialOrtographicSize = cameraComponent.orthographicSize;
    }

    public void ZoomIn(float posX, float posY, float ortographicSize)
    {
        StartCoroutine(SlowZoom());
        cameraComponent.gameObject.GetComponent<RectTransform>().position = new Vector3(posX, posY, -10);
        cameraComponent.orthographicSize = ortographicSize;
    }

    private IEnumerator SlowZoom()
    {
        // Zoom slowly, try to make zoom out and in same method.
        
        yield return new WaitForSeconds(0.1f);
    }

    public void ZoomOut()
    {
        // SlowZoom();
        cameraComponent.gameObject.GetComponent<RectTransform>().position = new Vector3(initialPosX, initialPosY, -10);
        cameraComponent.orthographicSize = initialOrtographicSize;
    }
}
