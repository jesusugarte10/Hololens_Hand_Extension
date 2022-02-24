using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{
    List<Vector3> linePoints;
    float timer;
    private float timerdelay;
    private bool flag = true;

    GameObject newLine;
    LineRenderer drawLine;

    // Start is called before the first frame update
    void Start()
    {
        linePoints = new List<Vector3>();
        timer = timerdelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPinching() && flag)
        {
            newLine = new GameObject();
            Destroy(newLine, 20);
            drawLine = newLine.AddComponent<LineRenderer>();
            drawLine.material = new Material(Shader.Find("Sprites/Default"));
            drawLine.startColor = Color.white;
            drawLine.endColor = Color.white;
            drawLine.startWidth = 0.01f;
            drawLine.endWidth = 0.01f;
            flag = false;
        }

        if (IsPinching() && GameObject.Find("Right_ShellHandRayPointer(Clone)"))
        {

            Debug.Log(IsPinching());
            Debug.DrawRay(Camera.main.ScreenToWorldPoint(
                GameObject.Find("Right_ShellHandRayPointer(Clone)").transform.position),
                GetHandPosition(), Color.red);

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                linePoints.Add(GetHandPosition());
                drawLine.positionCount = linePoints.Count;
                drawLine.SetPositions(linePoints.ToArray());

                timer = timerdelay;
            }
        }

        //Clear List for next drawing attempt 
        if (!IsPinching() && !flag)
        {
            flag = true;
            linePoints.Clear();
        }
    }

    //get User Input
    bool IsPinching()
    {
        float pinchThreshold = 0.7f;
        return HandPoseUtils.CalculateIndexPinch(Handedness.Right) > pinchThreshold;
    }
    Vector3 GetHandPosition()
    {
        //get hand position
        GameObject line = GameObject.Find("Right_ShellHandRayPointer(Clone)");

        if (line)
        {
            if (GameObject.Find("Arrow_Condition"))
                return new Vector3(line.transform.position.x, line.transform.position.y - 0.2f, line.transform.position.z) + line.transform.forward * Arrow_Script.shift;
            else if (GameObject.Find("Point_Cloud"))
                return line.transform.position + line.transform.forward * Static_Hand.shift;
            else
                return line.transform.position + line.transform.forward * (Fake_Hand.shift);
        }

        else
            return new Vector3(0,0,0);
        
  
    }
}