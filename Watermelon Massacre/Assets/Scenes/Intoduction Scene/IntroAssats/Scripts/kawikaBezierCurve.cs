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

    public float timeToReachEnd = 1;//1 one second, 2 is two seconds, ect   Also 0.5 is half a second,ect
    void Start()
    {
        if (two_points == true)
        {
            StartCoroutine(bezierCurve(thingToMove, firstPoint, secondPoint, timeToReachEnd));
        }
        else if (three_points == true)
        {
            //StartCoroutine(bezierCurve(thingToMove, firstPoint.position, secondPoint.position, thirdPoint.position, timeToReachEnd));
        }
        else if (four_points == true)
        {
           // StartCoroutine(bezierCurve(thingToMove, firstPoint.position, secondPoint.position, thirdPoint.position, fourthPoint.position, timeToReachEnd));
        }
        else
        {
            Debug.LogError("You did not select a choice " + this.gameObject.name);
        }
    }

    private void Update()
    {
      

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

            float xPos2 = ((1 - (currentTime)) * firstPoint.rotation.eulerAngles.x) + ((currentTime) * secondPoint.rotation.eulerAngles.x);
            float yPos2 = ((1 - (currentTime)) * firstPoint.rotation.eulerAngles.y) + ((currentTime) * secondPoint.rotation.eulerAngles.y);
            float zPos2 = ((1 - (currentTime)) * firstPoint.rotation.eulerAngles.z) + ((currentTime) * secondPoint.rotation.eulerAngles.z);
            Debug.Log(new Vector3(xPos2,yPos2,zPos2));


         //   Debug.Log(new Vector3(xPos, yPos, zPos) + " b");
            Debug.Log(new Vector3(xPos2, yPos2, zPos2) + " dd");
            objectToMove.transform.position = new Vector3(xPos, yPos, zPos);
            objectToMove.eulerAngles = new Vector3(xPos2, yPos2, zPos2);
           //  objectToMove.transform.rotation = Quaternion.LookRotation(new Vector3(xPos2, yPos2, zPos2));



            // Debug.Log(new Quaternion(xRot, yRot, zRot, -1));
            // objectToMove.transform.rotation = new Quaternion(xRot, yRot, zRot, 20);
            //  objectToMove.LookAt(new Vector3(xPos2,yPos2,zPos2));
            // objectToMove.transform.rotation = Quaternion.LookRotation(new Vector3(xPos2, yPos2, zPos2));

            if (i >= 250)
            {
                currentTime = 100000;
            }
            yield return new WaitForEndOfFrame();
        }
     
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

