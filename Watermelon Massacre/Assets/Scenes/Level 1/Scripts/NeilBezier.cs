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

    public float t = 0;

    void Start()
    {
        mainCam.depth = startCam.depth + 1;
        startCam.cullingMask = 1 << 0;
        startCamera.SetActive(true);
        mainCamera.SetActive(false);

        StartCoroutine(bezierCurve(bezierObject, startPoint, controlPoint, endPoint, t));
    }

    public IEnumerator bezierCurve(Transform bezierObject, Transform startPos, Transform controlPos, Transform endPos, float timer)
    {
        int check = 0;
        while (check == 0)
        {
            t = t + (Time.deltaTime / 2);
            if (t > 1)
            {
                t = 1;
                check = 1;
            }
            bezierObject.position = (1 - t) * (1 - t) * startPos.position + 2 * (1 - t) * t * controlPos.position + t * t * endPos.position;
            yield return new WaitForEndOfFrame();
        }
        startCamera.SetActive(false);
        mainCamera.SetActive(true);

    }
}
