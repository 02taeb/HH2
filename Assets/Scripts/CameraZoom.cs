using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    //TODO: Needs rewriting for canvas

    [SerializeField] private Camera cameraComponent;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private bool resetOnExit;
    [Tooltip("Field of view camera should change to if camera is in perspective mode")]
    [SerializeField] private float newFieldOfView;
    [Tooltip("Ortographic size camera should change to if camera is in perspective mode")]
    [SerializeField] private float newOrtographicSize;
    private float zoomFactor = 100f;
    private float initialFieldOfView;
    private float initialOrtographicSize;

    private void Start()
    {
        if (cameraComponent.orthographic)
        {
            initialOrtographicSize = cameraComponent.orthographicSize;
        } 
        else
        {
            initialFieldOfView = cameraComponent.fieldOfView;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(SlowChangeOut());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && resetOnExit)
        {
            StopAllCoroutines();
            StartCoroutine(SlowChangeIn());
        }
    }

    private IEnumerator SlowChangeOut()
    {
        if (cameraComponent.orthographic)
        {
            StartCoroutine(Ortographic(newOrtographicSize));
        }
        else
        {
            StartCoroutine(Perspective(newFieldOfView));
        }

        yield return null;
    }

    private IEnumerator SlowChangeIn()
    {
        if (cameraComponent.orthographic)
        {
            StartCoroutine(Ortographic(initialOrtographicSize));
        }
        else
        {
            StartCoroutine(Perspective(initialFieldOfView));
        }

        yield return null;
    }

    private IEnumerator Ortographic(float newSize)
    {
        float currentSize = cameraComponent.orthographicSize;
        float difference;

        if (newSize < cameraComponent.orthographicSize)
        {
            difference = currentSize - newSize;
        }
        else
        {
            difference = newSize - currentSize;
        }

        for (int i = 0; i < difference * zoomFactor; i++)
        {
            if (newSize < currentSize)
            {
                currentSize -= 1 / zoomFactor;
            }
            else 
            {
                currentSize += 1 / zoomFactor;
            }

            cameraComponent.orthographicSize = currentSize;
            yield return new WaitForSeconds(1 / (zoomFactor * zoomSpeed * 10));
        }
    }

    private IEnumerator Perspective(float newFOV)
    {
        float currentFov = cameraComponent.fieldOfView;
        float difference;

        if (newFOV < currentFov)
        {
            difference = currentFov - newFOV;
        }
        else
        {
            difference = newFOV - currentFov;
        }

        for (int i = 0; i < difference * zoomFactor; i++)
        {
            if (newFOV < currentFov)
            {
                currentFov -= 1 / zoomFactor;
            }
            else
            {
                currentFov += 1 / zoomFactor;
            }

            cameraComponent.fieldOfView = currentFov;
            yield return new WaitForSeconds(1 / (zoomFactor * zoomSpeed * 10));
        }
    }
}
