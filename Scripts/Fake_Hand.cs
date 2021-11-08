using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class Fake_Hand : MonoBehaviour {
   public GameObject marker;
   public GameObject marker2;

   public float shift = 3f;
   private float current;
   private Vector3 scale;
   private float scalefactorGrow;
   private float scalefactorShrink;

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
      //palmObject = Instantiate(marker, this.transform);
      palmObject.GetComponent<Renderer>().enabled = false;
      palmObject2.GetComponent<Renderer>().enabled = false;

      if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Right, out virtualHand)) {

         //position
         GameObject line = GameObject.Find("Right_ShellHandRayPointer(Clone)");
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
         if (current != shift) {
            scalefactorGrow = palmObject.transform.localScale.x + 0.004f;
            scalefactorShrink = palmObject.transform.localScale.x - 0.004f;

            // increase size
            if (current < shift)
               //palmObject.transform.localScale = new Vector3(scalefactorGrow, scalefactorGrow, scalefactorGrow);

            //decrease size 
            if (current > shift)
               //palmObject.transform.localScale = new Vector3(scalefactorShrink, scalefactorShrink, scalefactorShrink);
            current = shift;
         }


         //Shift
         float distance = Vector3.Distance(virtualHand.Position, Camera.main.transform.position);
         if (distance > 0.58) {
            if (shift < 10) 
               shift += 0.05f; 
         }
         else if (distance < 0.45) {
            if (shift > 0.5)
               shift -= 0.05f;
         }
         
         palmObject.GetComponent<Renderer>().enabled = true;
      }


      if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Left, out virtualHand)) {

         //position
         GameObject line = GameObject.Find("Left_ShellHandRayPointer(Clone)");
         palmObject2.transform.position = line.transform.position + line.transform.forward * shift;



         //Update Rotation
         Quaternion rot = virtualHand.Rotation;
         palmObject2.transform.rotation = rot;

         palmObject2.transform.eulerAngles = new Vector3(
             palmObject2.transform.eulerAngles.x ,
             palmObject2.transform.eulerAngles.y ,
             palmObject2.transform.eulerAngles.z 
         );




         //scaling
         if (current != shift) {
            scalefactorGrow = palmObject.transform.localScale.x + 0.004f;
            scalefactorShrink = palmObject.transform.localScale.x - 0.004f;

            // increase size
            if (current < shift)
               //palmObject.transform.localScale = new Vector3(scalefactorGrow, scalefactorGrow, scalefactorGrow);

               //decrease size 
               if (current > shift)
                  //palmObject.transform.localScale = new Vector3(scalefactorShrink, scalefactorShrink, scalefactorShrink);
                  current = shift;
         }


         //Shift
         float distance = Vector3.Distance(virtualHand.Position, Camera.main.transform.position);
         if (distance > 0.55) {
            if (shift < 10)
            shift += 0.01f;
         }
         else if (distance < 0.38) {
            if (shift > 0.5)
               shift -= 0.01f;
         }

         palmObject2.GetComponent<Renderer>().enabled = true;
      }
   }
}