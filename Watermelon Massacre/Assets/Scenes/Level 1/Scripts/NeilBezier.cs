using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeilBezier : MonoBehaviour
{
    public Camera startCam;
    public Camera mainCam;

    public GameObject startCamera;
    public GameObject mainCamera;
    
    public Transform bezierObject;

    public Transform startPoint;
    public Transform controlPoint;
    public Transform endPoint;

    public float timer;

    void Start()
    {
        mainCam.depth = startCam.depth + 1;
        startCam.cullingMask = 1 << 0;
        startCamera.SetActive(true);
        mainCamera.SetActive(false);

        StartCoroutine(bezierCurve(bezierObject, startPoint.position, controlPoint.position, endPoint.position, timer));
    }

    public IEnumerator bezierCurve(Transform bezierObject, Vector3 startPos, Vector3 controlPos, Vector3 endPos, float timer)
    {
        float currentTime = 0.0f;
        int i = 0;

        while(currentTime < 1)
        {
            i++;
            currentTime = Time.deltaTime / timer;

            if(currentTime >= 1)
            {
                currentTime = 1;
            }

            float xPos = (Mathf.Pow((1 - currentTime), 2) * startPos.x) + (2 * (1 - currentTime) * currentTime * controlPos.x) + (Mathf.Pow(currentTime, 2) * endPos.x);
            float yPos = (Mathf.Pow((1 - currentTime), 2) * startPos.y) + (2 * (1 - currentTime) * currentTime * controlPos.y) + (Mathf.Pow(currentTime, 2) * endPos.y);
            float zPos = (Mathf.Pow((1 - currentTime), 2) * startPos.z) + (2 * (1 - currentTime) * currentTime * controlPos.z) + (Mathf.Pow(currentTime, 2) * endPos.z);


            bezierObject.position = new Vector3(xPos, yPos, zPos);

            if(i >= 250)
            {
                currentTime = 100000;
                startCamera.SetActive(false);
                mainCamera.SetActive(true);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
