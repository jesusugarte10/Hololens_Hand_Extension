using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class Fake_Hand : MonoBehaviour {
   public GameObject marker;
   public GameObject marker2;
   public GameObject marker3;
   public GameObject marker4;

   public float shift = 3f;
   public float k = 5;
   private float current;
   private Vector3 scale;
   private float scalefactorGrow;
   private float scalefactorShrink;

   public float extend;
   public float shrink;

   private bool calibraton = false;

   private bool confirmation1 = false;
   private bool confirmation2 = false;

   private float Far_distance;
   private float Short_distance;

   GameObject palmObject;
   GameObject palmObject2;
   GameObject visualizer;

   public bool rateControl;
   public bool positionControl;
   public bool scaleControl;

   MixedRealityPose virtualHand;


   // Start is called before the first frame update
   void Start() {
      current = shift;
      palmObject = Instantiate(marker, this.transform);
      palmObject2 = Instantiate(marker2, this.transform);
      visualizer = Instantiate(marker3, this.transform);
   }

   // Update is called once per frame
   void Update() {
      palmObject.GetComponent<Renderer>().enabled = false;
      palmObject2.GetComponent<Renderer>().enabled = false;
      visualizer.GetComponent<Renderer>().enabled = false;


      Calibrate();

      if (calibraton) {
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out virtualHand)) {

            GameObject line = GameObject.Find("Right_ShellHandRayPointer(Clone)");
            //position
            palmObject.transform.position = line.transform.position + line.transform.forward * shift;

            //Update Rotation
            Quaternion rot = virtualHand.Rotation;
            palmObject.transform.rotation = rot;

            palmObject.transform.eulerAngles = new Vector3(
                  palmObject.transform.eulerAngles.x,
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

            //Visualize Region
            //Visualize(line);

            palmObject.GetComponent<Renderer>().enabled = true;

            Draw();
         }


         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out virtualHand)) {

            GameObject line = GameObject.Find("Left_ShellHandRayPointer(Clone)");
            //position
            palmObject2.transform.position = line.transform.position + line.transform.forward * shift;

            //Update Rotation
            Quaternion rot = virtualHand.Rotation;
            palmObject2.transform.rotation = rot;

            palmObject2.transform.eulerAngles = new Vector3(
                palmObject2.transform.eulerAngles.x,
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

   void Draw() {
      if (IsPinching()) {
         Destroy(Instantiate(marker4, palmObject.transform.position, Quaternion.identity), 20);
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

   void ShiftFunction(float extend, float shrink) {
      //Shift
      float distance = Vector3.Distance(virtualHand.Position, Camera.main.transform.position);
      if (distance > extend){
         if (shift < 10)
            shift += 0.01f;
      }
      else if (distance < shrink) {
         if (shift > 0)
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
            current = shift;
         }

      }
   }

   void Visualize(GameObject line) {
      visualizer.transform.position = Camera.main.transform.position + Camera.main.transform.forward * Short_distance*0.1f + new Vector3(0f,-0.2f,0f);
      visualizer.transform.localScale = new Vector3(0.01f, (Far_distance - Short_distance)*0.1f, 0.01f);

      //Update Rotation
      Quaternion rot = virtualHand.Rotation;
      palmObject2.transform.rotation = rot;


      visualizer.transform.eulerAngles = new Vector3(
          visualizer.transform.eulerAngles.x,
          visualizer.transform.eulerAngles.y,
          visualizer.transform.eulerAngles.z
      );

      visualizer.GetComponent<Renderer>().enabled = true;
   }


   void Calibrate() {

      if (!calibraton){

         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out virtualHand)){
            
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
            
            extend = Far_distance ;
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


