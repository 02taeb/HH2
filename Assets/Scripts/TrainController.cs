using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private int maxTargets;
    [SerializeField] private GameObject targetPrefab, targetParent;
    private float timer;
    private int spawned;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > spawnTimer)
        {
            timer = 0;
            if (spawned < maxTargets)
            {
                //Spawn target
            }
        }

    }

    public void HitTarget()
    {

    }
}
