using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class Arrow_Script : MonoBehaviour {

   private GameObject temp;
   public GameObject splineParent;
   private GameObject splinePoint;

    public GameObject marker;
   public GameObject marker2;
   public GameObject marker4;

   public static float shift = 3f;
   public float k = 5;
   private float current;
   private Vector3 scale;
   private float scalefactorGrow;
   private float scalefactorShrink;

   public bool rateControl;
   public bool positionControl;
   public bool scaleControl;

   public float extend;
   public float shrink;

   private bool calibraton = false;

   private bool confirmation1 = false;
   private bool confirmation2 = false;

   private float Far_distance ;
   private float Short_distance ;

   GameObject palmObject;
   GameObject palmObject2;

   MixedRealityPose virtualHand;


    // Start is called before the first frame update
    void Start() {
      current = shift;
      palmObject = Instantiate(marker, this.transform);
      palmObject2 = Instantiate(marker2, this.transform);
   }

   // Update is called once per frame
   void Update() {
      palmObject.GetComponent<Renderer>().enabled = false;
      palmObject2.GetComponent<Renderer>().enabled = false;


      Calibrate();

      if (calibraton) {
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out virtualHand)) {


            //position
            GameObject line = GameObject.Find("Right_ShellHandRayPointer(Clone)");
            palmObject.transform.position = line.transform.position + line.transform.forward * shift;


            //Update Rotation
            Quaternion rot = virtualHand.Rotation;
            palmObject.transform.rotation = rot;

            palmObject.transform.eulerAngles = new Vector3(
                  palmObject.transform.eulerAngles.x + 90,
                  palmObject.transform.eulerAngles.y,
                  palmObject.transform.eulerAngles.z
            );

            //scaling
            Scaling();

            //Shift
            if (rateControl)
               ShiftFunction(extend, shrink);

            //Position Control Shift
            if (positionControl)
               PositionControl(extend, shrink);

            palmObject.GetComponent<Renderer>().enabled = true;

            Draw();
         }


         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out virtualHand)) {

            //position
            GameObject line = GameObject.Find("Left_ShellHandRayPointer(Clone)");
            palmObject2.transform.position = line.transform.position + line.transform.forward * shift;

            //Update Rotation
            Quaternion rot = virtualHand.Rotation;
            palmObject2.transform.rotation = rot;

            palmObject2.transform.eulerAngles = new Vector3(
                palmObject2.transform.eulerAngles.x + 90,
                palmObject2.transform.eulerAngles.y,
                palmObject2.transform.eulerAngles.z
            );


            //scaling
            Scaling();

            //Shift
            if (rateControl)
               ShiftFunction(extend, shrink);

            //Position Control Shift
            if (positionControl)
               PositionControl(extend, shrink);

            palmObject2.GetComponent<Renderer>().enabled = true;


            Delete();
         }
      }
   }

   void ShiftFunction(float extend, float shrink) {
      //Shift
      float distance = Vector3.Distance(virtualHand.Position, Camera.main.transform.position);
      if (distance > extend) {
         if (shift < 10)
            shift += 0.01f;
      }
      else if (distance < shrink) {
         if (shift > 0.8) // Modify this for how far you want the object to be
            shift -= 0.01f;
      }
   }

   void PositionControl(float extend, float shrink) {

      float distance = Vector3.Distance(virtualHand.Position, Camera.main.transform.position);

      if (distance > extend - (extend - shrink) / 2) {
         shift = k * (distance - extend / 2) * Mathf.Exp(2);
      }
   }


   void Scaling() {
      if (scaleControl) {
         if (current != shift) {
            scalefactorGrow = palmObject.transform.localScale.x + 0.02f;

            if(palmObject.transform.localScale.x >=1f)
                scalefactorShrink = palmObject.transform.localScale.x - 0.02f;

            // increase size
            if (current < shift) {
               palmObject.transform.localScale = new Vector3(scalefactorGrow, scalefactorGrow, scalefactorGrow);
               palmObject2.transform.localScale = new Vector3(scalefactorGrow, scalefactorGrow, scalefactorGrow);
            }
            //decrease size 
            if (current > shift) {
               palmObject.transform.localScale = new Vector3(scalefactorShrink, scalefactorShrink, scalefactorShrink);
               palmObject2.transform.localScale = new Vector3(scalefactorShrink, scalefactorShrink, scalefactorShrink);
            }

            //reset
            if (shift < 1f) {
               palmObject.transform.localScale = new Vector3(1f, 1f, 1f);
               palmObject2.transform.localScale = new Vector3(1f, 1f, 1f);
            }

            current = shift;
         }

      }
   }
    
    void Draw() {
      if (IsPinching()) {
            //splinePoint = Instantiate(marker4, palmObject.transform.position, Quaternion.identity);
            //splinePoint.transform.parent = splineParent.transform;
            //splinePoint.name = $"{transform.childCount+1}";
            //Destroy(splinePoint, 20);
            //if(temp != null)
            //{
                //Debug.DrawLine(splinePoint.transform.position, temp.transform.position, Color.green,Time.deltaTime, false);
                //Debug.Log("HERE Drawing");
            //}
            //temp = splinePoint;
        }
   }

   bool IsPinchingLeft() {
      float pinchThreshold = 0.7f;

      if (rateControl && HandPoseUtils.CalculateIndexPinch(Handedness.Left) > pinchThreshold) {
         rateControl = false;
         positionControl = true;
      }
      else if (HandPoseUtils.CalculateIndexPinch(Handedness.Left) > pinchThreshold) {
         rateControl = true;
         positionControl = false;
      }

      return HandPoseUtils.CalculateIndexPinch(Handedness.Left) > pinchThreshold;
   }

   bool IsPinching() {
      float pinchThreshold = 0.7f;
      return HandPoseUtils.CalculateIndexPinch(Handedness.Right) > pinchThreshold;
   }

   void Delete() {
      if (IsPinchingLeft()) {
         var clones = GameObject.FindGameObjectsWithTag("draw");
         foreach (var clone in clones) {
            Destroy(clone);
         }
      }
   }

   void Calibrate() {

      if (!calibraton){

         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Right, out virtualHand)){
            
            if(!confirmation1) {
               //Measure distance from hand to camera
               Far_distance = Vector3.Distance(virtualHand.Position, Camera.main.transform.position);

               if (IsPinching()) {
                  confirmation1 = true;
                  Debug.Log("Success1");
               }
            }

            bool condition = (Far_distance - (Far_distance * 0.2f)) > Vector3.Distance(virtualHand.Position, Camera.main.transform.position);

            //ensure first condition is satisfied
            if (confirmation1  && !confirmation2 && condition) {
               //Measure distance from hand to camera
               Short_distance = Vector3.Distance(virtualHand.Position, Camera.main.transform.position);

               if (IsPinching()) {
                  confirmation2 = true;
                  Debug.Log("Success2");
               }
            }
         }

         if (confirmation1 && confirmation2) {
            float Total_Range = Far_distance - Short_distance;

            extend = Far_distance;
            shrink = Short_distance + 0.05f;

            //break down
            /*
            [--------/////////////////+++++++++] 
             shrink       free         extend
             
            shrink 20%
            extend 20%
            free 60%

            */

            Debug.Log("extend: "+ extend);
            Debug.Log("shrink: "+ shrink);
            Debug.Log("Calibration Sucess");
            calibraton = true;
         }
      }
   }
}


