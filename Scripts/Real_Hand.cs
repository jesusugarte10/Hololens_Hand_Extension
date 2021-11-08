using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;


public class Real_Hand : MonoBehaviour
{
   private GameObject maradonna_Right;
   private GameObject maradonna_Left;
   public float shift = 1;
   MixedRealityPose virtualHand;

   // Update is called once per frame
   void LateUpdate()
    {
      if (GameObject.Find("R_Wrist")) {
         maradonna_Right = GameObject.Find("R_Wrist");
         ShowHand(maradonna_Right);
      }
      if (GameObject.Find("L_Wrist")) {
         maradonna_Left = GameObject.Find("L_Wrist");
         ShowHand(maradonna_Left);
      }
   }

   void ShowHand(GameObject hand) {
      
      GameObject line = GameObject.Find("Right_ShellHandRayPointer(Clone)");
      if(line)
         hand.transform.position += line.transform.position + line.transform.forward * shift;

      Shift();
      
   }

   void Shift() {
      if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Right, out virtualHand)) {
         
         float distance = Vector3.Distance(virtualHand.Position, Camera.main.transform.position);
         //Shift
         if (distance > 0.55) {
            if (shift < 10)
               shift += 0.01f;
         }
         else if (distance < 0.42) {
            if (shift > 0.5)
               shift -= 0.01f;
         }
      }
   }
}
