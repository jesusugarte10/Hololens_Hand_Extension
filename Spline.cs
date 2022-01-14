using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{
    private Vector3[] splinePoint;
    private int splineCount;

    public bool debug_drawspline = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        splineCount = transform.childCount;
        splinePoint = new Vector3[splineCount];

        for (int i = 0; i < splineCount; i++)
        {
            splinePoint[i] = transform.GetChild(i).position;
        }

        if (splineCount > 1)
        {
            for (int i = 0; i < splineCount-1; i++)
            {
                Debug.DrawLine(splinePoint[i], splinePoint[i + 1], Color.green);
                Debug.Log("HERE Drawing");
            }
        }*/
    }
}