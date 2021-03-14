using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomanCurve : MonoBehaviour
{
    public Transform thingToMove;
    public Transform start;
    public Transform mid;
    public Transform end;
    public float t = 0;



    // Start is called before the first frame update
    void Start()
    {
        //Curve();
        StartCoroutine(runCurve(thingToMove, start, mid, end, t));
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            StartCoroutine(runCurve(thingToMove, start, mid, end, 0));
    }
    public IEnumerator runCurve(Transform thingToMove, Transform start, Transform mid, Transform end, float t)
    {
        int termPls = 0;
        while (termPls == 0) {
            t = t + Time.deltaTime;
            //Debug.Log(Time.deltaTime);
            //Debug.Log(t);
            if (t > 1)
            {
                t = 1;
                termPls = 1;
            }
        //B(t) = (1-t)2P0 + 2(1-t)tP1 + t2P2 
        thingToMove.position = (1 - t) * (1 - t) * start.position + 2 * (1 - t) * t * mid.position + t * t * end.position;
            Debug.Log(thingToMove.position.x);
    }
        yield return new WaitForEndOfFrame();  
    }
}
