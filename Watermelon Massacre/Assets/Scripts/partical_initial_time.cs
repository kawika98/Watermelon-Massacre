using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partical_initial_time : MonoBehaviour
{
    public float startTime;
    public ParticleSystem particals;
    void Start()
    {
        if(startTime == 0 || startTime == null)
        {
            Debug.LogError("There is no start time for " + this.name + " fix it");
        }
        else
        {
            particals.Simulate(startTime);
        }
    }

   
}
