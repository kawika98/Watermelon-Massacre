using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kawikaBezierCurve : MonoBehaviour
{
    public Transform thingToMove;

    public Transform firstPoint;
    public Transform secondPoint;
    public Transform thirdPoint;
    public Transform fourthPoint;

    [Header("Use two points")]
    public bool two_points;
    [Header("Use three points")]
    public bool three_points;
    [Header("Use four points")]
    public bool four_points;

    private bool done = false;
    public GameObject main_one;
    public GameObject not_main_one;
    public GameObject cav_my;
    public GameObject b_music;

    public bool useCheck = false;

    private void Update()
    {
        if(useCheck == true)
        {

            if (done == true)
            {
                main_one.gameObject.SetActive(false);
                not_main_one.gameObject.SetActive(true);
                cav_my.gameObject.SetActive(true);
                b_music.gameObject.SetActive(true);
            }
        }
   
    }

    public float timeToReachEnd = 1;//1 one second, 2 is two seconds, ect   Also 0.5 is half a second,ect
    void Start()
    {
        if (two_points == true)
        {
            StartCoroutine(bezierCurve(thingToMove, firstPoint, secondPoint, timeToReachEnd));
        }
        else if (three_points == true)
        {
            StartCoroutine(bezierCurve(thingToMove, firstPoint, secondPoint, thirdPoint, timeToReachEnd));
        }
        else if (four_points == true)
        {
           StartCoroutine(bezierCurve(thingToMove, firstPoint, secondPoint, thirdPoint, fourthPoint, timeToReachEnd));
        }
        else
        {
            Debug.LogError("You did not select a choice " + this.gameObject.name);
        }
    }
    public IEnumerator bezierCurve(Transform objectToMove, Transform firstPoint, Transform secondPoint, float timeToReachEnd)
    {
        float currentTime = 0.0f;
        int i = 0;

        while(currentTime < 1)
        {
            i++;
            currentTime += Time.deltaTime/timeToReachEnd;

            if(currentTime >= 1)
            {
                currentTime = 1;
            }

            float xPos = ((1 - currentTime) * firstPoint.position.x) + (currentTime * secondPoint.position.x);
            float yPos = ((1 - currentTime) * firstPoint.position.y) + (currentTime * secondPoint.position.y);
            float zPos = ((1 - currentTime) * firstPoint.position.z) + (currentTime * secondPoint.position.z);

            float xRot = ((1 - (currentTime)) * firstPoint.rotation.eulerAngles.x) + ((currentTime) * secondPoint.rotation.eulerAngles.x);
            float yRot = ((1 - (currentTime)) * firstPoint.rotation.eulerAngles.y) + ((currentTime) * secondPoint.rotation.eulerAngles.y);
            float zRot = ((1 - (currentTime)) * firstPoint.rotation.eulerAngles.z) + ((currentTime) * secondPoint.rotation.eulerAngles.z);


            objectToMove.transform.position = new Vector3(xPos, yPos, zPos);
            objectToMove.eulerAngles = new Vector3(xRot, yRot, zRot);         

            if (i >= 250)
            {
                currentTime = 100000;
            }
            yield return new WaitForEndOfFrame();
        }
        done = true;
     
    }

    public IEnumerator bezierCurve(Transform objectToMove, Transform firstPoint, Transform secondPoint,Transform thirdPoint, float timeToReachEnd)
    {
        float currentTime = 0.0f;
        int i = 0;

        while (currentTime < 1)
        {
            i++;
            currentTime += Time.deltaTime / timeToReachEnd;

            if (currentTime >= 1)
            {
                currentTime = 1;
            }

            float xPos = (Mathf.Pow((1 - currentTime), 2) * firstPoint.position.x) + (2 * (1 - currentTime) * currentTime * secondPoint.position.x) + (Mathf.Pow(currentTime, 2) * thirdPoint.position.x);
            float yPos = (Mathf.Pow((1 - currentTime), 2) * firstPoint.position.y) + (2 * (1 - currentTime) * currentTime * secondPoint.position.y) + (Mathf.Pow(currentTime, 2) * thirdPoint.position.y);
            float zPos = (Mathf.Pow((1 - currentTime), 2) * firstPoint.position.z) + (2 * (1 - currentTime) * currentTime * secondPoint.position.z) + (Mathf.Pow(currentTime, 2) * thirdPoint.position.z);

            float xRot = (Mathf.Pow((1 - currentTime), 2) * firstPoint.rotation.eulerAngles.x) + (2 * (1 - currentTime) * currentTime * secondPoint.rotation.eulerAngles.x) + (Mathf.Pow(currentTime, 2) * thirdPoint.rotation.eulerAngles.x);
            float yRot = (Mathf.Pow((1 - currentTime), 2) * firstPoint.rotation.eulerAngles.y) + (2 * (1 - currentTime) * currentTime * secondPoint.rotation.eulerAngles.y) + (Mathf.Pow(currentTime, 2) * thirdPoint.rotation.eulerAngles.y);
            float zRot = (Mathf.Pow((1 - currentTime), 2) * firstPoint.rotation.eulerAngles.z) + (2 * (1 - currentTime) * currentTime * secondPoint.rotation.eulerAngles.z) + (Mathf.Pow(currentTime, 2) * thirdPoint.rotation.eulerAngles.z);



            objectToMove.transform.position = new Vector3(xPos, yPos, zPos);
            objectToMove.eulerAngles = new Vector3(xRot, yRot, zRot);

            if (i >= 250)
            {
                currentTime = 100000;
            }
            yield return new WaitForEndOfFrame();
        }
        done = true;

    }

    public IEnumerator bezierCurve(Transform objectToMove, Transform firstPoint, Transform secondPoint, Transform thirdPoint,Transform fourthPoint, float timeToReachEnd)
    {
        float currentTime = 0.0f;
        int i = 0;

        while (currentTime < 1)
        {
            i++;
            currentTime += Time.deltaTime / timeToReachEnd;

            if (currentTime >= 1)
            {
                currentTime = 1;
            }

            float xPos = (Mathf.Pow((1 - currentTime), 3) * firstPoint.position.x) + (3 * Mathf.Pow((1 - currentTime), 2) * currentTime * secondPoint.position.x) + (3 * (1 - currentTime) * Mathf.Pow(currentTime, 2) * thirdPoint.position.x) + (Mathf.Pow(currentTime, 3) * fourthPoint.position.x);
            float yPos = (Mathf.Pow((1 - currentTime), 3) * firstPoint.position.y) + (3 * Mathf.Pow((1 - currentTime), 2) * currentTime * secondPoint.position.y) + (3 * (1 - currentTime) * Mathf.Pow(currentTime, 2) * thirdPoint.position.y) + (Mathf.Pow(currentTime, 3) * fourthPoint.position.y);
            float zPos = (Mathf.Pow((1 - currentTime), 3) * firstPoint.position.z) + (3 * Mathf.Pow((1 - currentTime), 2) * currentTime * secondPoint.position.z) + (3 * (1 - currentTime) * Mathf.Pow(currentTime, 2) * thirdPoint.position.z) + (Mathf.Pow(currentTime, 3) * fourthPoint.position.z);

            float xRot = (Mathf.Pow((1 - currentTime), 3) * firstPoint.rotation.eulerAngles.x) + (3 * Mathf.Pow((1 - currentTime), 2) * currentTime * secondPoint.rotation.eulerAngles.x) + (3 * (1 - currentTime) * Mathf.Pow(currentTime, 2) * thirdPoint.rotation.eulerAngles.x) + (Mathf.Pow(currentTime, 3) * fourthPoint.rotation.eulerAngles.x);
            float yRot = (Mathf.Pow((1 - currentTime), 3) * firstPoint.rotation.eulerAngles.y) + (3 * Mathf.Pow((1 - currentTime), 2) * currentTime * secondPoint.rotation.eulerAngles.y) + (3 * (1 - currentTime) * Mathf.Pow(currentTime, 2) * thirdPoint.rotation.eulerAngles.y) + (Mathf.Pow(currentTime, 3) * fourthPoint.rotation.eulerAngles.y);
            float zRot = (Mathf.Pow((1 - currentTime), 3) * firstPoint.rotation.eulerAngles.z) + (3 * Mathf.Pow((1 - currentTime), 2) * currentTime * secondPoint.rotation.eulerAngles.z) + (3 * (1 - currentTime) * Mathf.Pow(currentTime, 2) * thirdPoint.rotation.eulerAngles.z) + (Mathf.Pow(currentTime, 3) * fourthPoint.rotation.eulerAngles.z);



            objectToMove.transform.position = new Vector3(xPos, yPos, zPos);
            objectToMove.eulerAngles = new Vector3(xRot, yRot, zRot);

            if (i >= 250)
            {
                currentTime = 100000;
            }
            yield return new WaitForEndOfFrame();
        }
        done = true;

    }

    //public IEnumerator bezierCurve(Transform objectToMove, Vector3 firstPoint, Vector3 secondPoint,Vector3 thirdPoint, float timeToReachEnd)
    //{
    //    float currentTime = 0.0f;
    //    int i = 0;

    //    while (currentTime < 1)
    //    {
    //        i++;
    //        currentTime += Time.deltaTime / timeToReachEnd;

    //        if (currentTime >= 1)
    //        {
    //            currentTime = 1;
    //        }

    //        float xPos = (Mathf.Pow((1 - currentTime), 2) * firstPoint.x) + (2 * (1-  currentTime) * currentTime * secondPoint.x) + (Mathf.Pow(currentTime,2) *  thirdPoint.x);
    //        float yPos = (Mathf.Pow((1 - currentTime), 2) * firstPoint.y) + (2 * (1 - currentTime) * currentTime * secondPoint.y) + (Mathf.Pow(currentTime, 2) * thirdPoint.y);
    //        float zPos = (Mathf.Pow((1 - currentTime), 2) * firstPoint.z) + (2 * (1 - currentTime) * currentTime * secondPoint.z) + (Mathf.Pow(currentTime, 2) * thirdPoint.z);

    //        objectToMove.transform.position = new Vector3(xPos, yPos, zPos);

    //        if (i >= 250)
    //        {
    //            currentTime = 100000;
    //        }
    //        yield return new WaitForEndOfFrame();
    //    }

    //}

    //public IEnumerator bezierCurve(Transform objectToMove, Vector3 firstPoint, Vector3 secondPoint, Vector3 thirdPoint,Vector4 fourthPoint, float timeToReachEnd)
    //{
    //    float currentTime = 0.0f;
    //    int i = 0;

    //    while (currentTime < 1)
    //    {
    //        i++;
    //        currentTime += Time.deltaTime / timeToReachEnd;

    //        if (currentTime >= 1)
    //        {
    //            currentTime = 1;
    //        }

    //        float xPos = (Mathf.Pow((1 - currentTime), 3) * firstPoint.x) + (3 * Mathf.Pow((1 - currentTime), 2) * currentTime * secondPoint.x) + (3 * (1 - currentTime) * Mathf.Pow(currentTime, 2) * thirdPoint.x) + (Mathf.Pow(currentTime, 3) * fourthPoint.x);
    //        float yPos = (Mathf.Pow((1 - currentTime), 3) * firstPoint.y) + (3 * Mathf.Pow((1 - currentTime), 2) * currentTime * secondPoint.y) + (3 * (1 - currentTime) * Mathf.Pow(currentTime, 2) * thirdPoint.y) + (Mathf.Pow(currentTime, 3) * fourthPoint.y);
    //        float zPos = (Mathf.Pow((1 - currentTime), 3) * firstPoint.z) + (3 * Mathf.Pow((1 - currentTime), 2) * currentTime * secondPoint.z) + (3 * (1 - currentTime) * Mathf.Pow(currentTime, 2) * thirdPoint.z) + (Mathf.Pow(currentTime, 3) * fourthPoint.z);


    //        objectToMove.transform.position = new Vector3(xPos, yPos, zPos);

    //        if (i >= 250)
    //        {
    //            currentTime = 100000;
    //        }
    //        yield return new WaitForEndOfFrame();
    //    }

    //}
}

