using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainController : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private int maxTargets;
    [SerializeField] private GameObject targetPrefab, targetParent, visIndicator;
    [SerializeField] private Vector3[] spawnPoses;
    [SerializeField] private Text feedback;
    private float timer;
    private float beatTimer, beat = 1 / (109 / 60); // 1/(109/60) because EyeOfTheTiger is (supposedly) 109 BPM,
                                                    // it feels kinda off but I'm unsure if it's performance, 
                                                    // Time.deltaTime of wrong beat (did use an unofficial instrumental version).
    private int spawned;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        beatTimer += Time.deltaTime;

        if(timer > spawnTimer)
        {
            timer = 0;
            if (spawned < maxTargets)
            {
                //Spawn target
                spawned++;
            }
        }

        if(beatTimer >= beat)
        {
            visIndicator.SetActive(true);
            beatTimer = 0;
            StartCoroutine(Reset());
        }
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.2f);

        visIndicator.SetActive(false);
    }

    public void HitTarget()
    {
        spawned--;
        Destroy(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject);
        if (visIndicator.activeSelf && beatTimer < 0.1)
        {
            feedback.text = "Perfect!";
            StartCoroutine(ResetText());
        }
        else if (visIndicator.activeSelf && beatTimer <= 0.2)
        {
            feedback.text = "Good!";
            StartCoroutine(ResetText());
        }
        else if (!visIndicator.activeSelf)
        {
            feedback.text = "Poor!";
            StartCoroutine(ResetText());
        }

    }

    private IEnumerator ResetText()
    {
        yield return new WaitForSeconds(0.5f);

        feedback.text = string.Empty;
    }
}
