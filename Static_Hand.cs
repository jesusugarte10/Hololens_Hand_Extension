using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class Static_Hand : MonoBehaviour {
   public GameObject marker;
   public float shift = 1f;
   public float k = 5;
   private float current;
   private Vector3 scale;
   public GameObject parent;
   public GameObject parent2;

   public float extend;
   public float shrink;

   private bool calibraton = false;

   private bool confirmation1 = false;
   private bool confirmation2 = false;

   private float Far_distance;
   private float Short_distance;

   public bool rateControl;
   public bool positionControl;
   public bool scaleControl;


   GameObject IndexDistalJoint;
   GameObject IndexKnuckle;
   GameObject IndexMetacarpal;
   GameObject IndexMiddleJoint;
   GameObject IndexTip;
   GameObject MiddleDistalJoint;
   GameObject MiddleKnuckle;
   GameObject MiddleMetacarpal;
   GameObject MiddleMiddleJoint;
   GameObject MiddleTip;
   GameObject Palm;
   GameObject PinkyDistalJoint;
   GameObject PinkyKnuckle;
   GameObject PinkyMetacarpal;
   GameObject PinkyMiddleJoint;
   GameObject PinkyTip;
   GameObject RingDistalJoint;
   GameObject RingKnuckle;
   GameObject RingMetacarpal;
   GameObject RingMiddleJoint;
   GameObject RingTip;
   GameObject ThumbDistalJoint;
   GameObject ThumbMetacarpalJoint;
   GameObject ThumbProximalJoint;
   GameObject ThumbTip;
   GameObject Wrist;

   GameObject LIndexDistalJoint;
   GameObject LIndexKnuckle;
   GameObject LIndexMetacarpal;
   GameObject LIndexMiddleJoint;
   GameObject LIndexTip;
   GameObject LMiddleDistalJoint;
   GameObject LMiddleKnuckle;
   GameObject LMiddleMetacarpal;
   GameObject LMiddleMiddleJoint;
   GameObject LMiddleTip;
   GameObject LPalm;
   GameObject LPinkyDistalJoint;
   GameObject LPinkyKnuckle;
   GameObject LPinkyMetacarpal;
   GameObject LPinkyMiddleJoint;
   GameObject LPinkyTip;
   GameObject LRingDistalJoint;
   GameObject LRingKnuckle;
   GameObject LRingMetacarpal;
   GameObject LRingMiddleJoint;
   GameObject LRingTip;
   GameObject LThumbDistalJoint;
   GameObject LThumbMetacarpalJoint;
   GameObject LThumbProximalJoint;
   GameObject LThumbTip;
   GameObject LWrist;

   public GameObject marker4;

   MixedRealityPose virtualHand;


   // Start is called before the first frame update
   void Start() {
      current = shift;

      //Left
      LIndexDistalJoint = Instantiate(marker, this.transform);
      LIndexDistalJoint.transform.parent = parent.transform;

      LIndexKnuckle = Instantiate(marker, this.transform);
      LIndexKnuckle.transform.parent = parent.transform;

      LIndexMetacarpal = Instantiate(marker, this.transform);
      LIndexMetacarpal.transform.parent = parent.transform;

      LIndexMiddleJoint = Instantiate(marker, this.transform);
      LIndexMiddleJoint.transform.parent = parent.transform;

      LIndexTip = Instantiate(marker, this.transform);
      LIndexTip.transform.parent = parent.transform;

      LMiddleDistalJoint = Instantiate(marker, this.transform);
      LMiddleDistalJoint.transform.parent = parent.transform;

      LMiddleKnuckle = Instantiate(marker, this.transform);
      LMiddleKnuckle.transform.parent = parent.transform;

      LMiddleMetacarpal = Instantiate(marker, this.transform);
      LMiddleMetacarpal.transform.parent = parent.transform;

      LMiddleMiddleJoint = Instantiate(marker, this.transform);
      LMiddleMiddleJoint.transform.parent = parent.transform;

      LMiddleTip = Instantiate(marker, this.transform);
      LMiddleTip.transform.parent = parent.transform;

      LPalm = Instantiate(marker, this.transform);
      LPalm.transform.parent = parent.transform;

      LPinkyDistalJoint = Instantiate(marker, this.transform);
      LPinkyDistalJoint.transform.parent = parent.transform;

      LPinkyKnuckle = Instantiate(marker, this.transform);
      LPinkyKnuckle.transform.parent = parent.transform;

      LPinkyMetacarpal = Instantiate(marker, this.transform);
      LPinkyMetacarpal.transform.parent = parent.transform;

      LPinkyMiddleJoint = Instantiate(marker, this.transform);
      LPinkyMiddleJoint.transform.parent = parent.transform;

      LPinkyTip = Instantiate(marker, this.transform);
      LPinkyTip.transform.parent = parent.transform;

      LRingDistalJoint = Instantiate(marker, this.transform);
      LRingDistalJoint.transform.parent = parent.transform;

      LRingKnuckle = Instantiate(marker, this.transform);
      LRingKnuckle.transform.parent = parent.transform;

      LRingMetacarpal = Instantiate(marker, this.transform);
      LRingMetacarpal.transform.parent = parent.transform;

      LRingMiddleJoint = Instantiate(marker, this.transform);
      LRingMiddleJoint.transform.parent = parent.transform;

      LRingTip = Instantiate(marker, this.transform);
      LRingTip.transform.parent = parent.transform;

      LThumbDistalJoint = Instantiate(marker, this.transform);
      LThumbDistalJoint.transform.parent = parent.transform;

      LThumbMetacarpalJoint = Instantiate(marker, this.transform);
      LThumbMetacarpalJoint.transform.parent = parent.transform;

      LThumbProximalJoint = Instantiate(marker, this.transform);
      LThumbProximalJoint.transform.parent = parent.transform;

      LThumbTip = Instantiate(marker, this.transform);
      LThumbTip.transform.parent = parent.transform;

      LWrist = Instantiate(marker, this.transform);
      LWrist.transform.parent = parent.transform;



      //Right
      IndexDistalJoint = Instantiate(marker, this.transform);
      IndexDistalJoint.transform.parent = parent2.transform;

      IndexKnuckle = Instantiate(marker, this.transform);
      IndexKnuckle.transform.parent = parent2.transform;

      IndexMetacarpal = Instantiate(marker, this.transform);
      IndexMetacarpal.transform.parent = parent2.transform;

      IndexMiddleJoint = Instantiate(marker, this.transform);
      IndexMiddleJoint.transform.parent = parent2.transform;

      IndexTip = Instantiate(marker, this.transform);
      IndexTip.transform.parent = parent2.transform;

      MiddleDistalJoint = Instantiate(marker, this.transform);
      MiddleDistalJoint.transform.parent = parent2.transform;

      MiddleKnuckle = Instantiate(marker, this.transform);
      MiddleKnuckle.transform.parent = parent2.transform;

      MiddleMetacarpal = Instantiate(marker, this.transform);
      MiddleMetacarpal.transform.parent = parent2.transform;

      MiddleMiddleJoint = Instantiate(marker, this.transform);
      MiddleMiddleJoint.transform.parent = parent2.transform;

      MiddleTip = Instantiate(marker, this.transform);
      MiddleTip.transform.parent = parent2.transform;

      Palm = Instantiate(marker, this.transform);
      Palm.transform.parent = parent2.transform;

      PinkyDistalJoint = Instantiate(marker, this.transform);
      PinkyDistalJoint.transform.parent = parent2.transform;

      PinkyKnuckle = Instantiate(marker, this.transform);
      PinkyKnuckle.transform.parent = parent2.transform;

      PinkyMetacarpal = Instantiate(marker, this.transform);
      PinkyMetacarpal.transform.parent = parent2.transform;

      PinkyMiddleJoint = Instantiate(marker, this.transform);
      PinkyMiddleJoint.transform.parent = parent2.transform;

      PinkyTip = Instantiate(marker, this.transform);
      PinkyTip.transform.parent = parent2.transform;

      RingDistalJoint = Instantiate(marker, this.transform);
      RingDistalJoint.transform.parent = parent2.transform;

      RingKnuckle = Instantiate(marker, this.transform);
      RingKnuckle.transform.parent = parent2.transform;

      RingMetacarpal = Instantiate(marker, this.transform);
      RingMetacarpal.transform.parent = parent2.transform;

      RingMiddleJoint = Instantiate(marker, this.transform);
      RingMiddleJoint.transform.parent = parent2.transform;

      RingTip = Instantiate(marker, this.transform);
      RingTip.transform.parent = parent2.transform;

      ThumbDistalJoint = Instantiate(marker, this.transform);
      ThumbDistalJoint.transform.parent = parent2.transform;

      ThumbMetacarpalJoint = Instantiate(marker, this.transform);
      ThumbMetacarpalJoint.transform.parent = parent2.transform;

      ThumbProximalJoint = Instantiate(marker, this.transform);
      ThumbProximalJoint.transform.parent = parent2.transform;

      ThumbTip = Instantiate(marker, this.transform);
      ThumbTip.transform.parent = parent2.transform;

      Wrist = Instantiate(marker, this.transform);
      Wrist.transform.parent = parent2.transform;

   }
   
   // Update is called once per frame
   void LateUpdate() {

      //Hiding Prefabs
      IndexDistalJoint.GetComponent<Renderer>().enabled = false;
      IndexKnuckle.GetComponent<Renderer>().enabled = false;
      IndexMetacarpal.GetComponent<Renderer>().enabled = false;
      IndexMiddleJoint.GetComponent<Renderer>().enabled = false;
      IndexTip.GetComponent<Renderer>().enabled = false;
      MiddleDistalJoint.GetComponent<Renderer>().enabled = false;
      MiddleKnuckle.GetComponent<Renderer>().enabled = false;
      MiddleMetacarpal.GetComponent<Renderer>().enabled = false;
      MiddleMiddleJoint.GetComponent<Renderer>().enabled = false;
      MiddleTip.GetComponent<Renderer>().enabled = false;
      Palm.GetComponent<Renderer>().enabled = false;
      PinkyDistalJoint.GetComponent<Renderer>().enabled = false;
      PinkyKnuckle.GetComponent<Renderer>().enabled = false;
      PinkyMetacarpal.GetComponent<Renderer>().enabled = false;
      PinkyMiddleJoint.GetComponent<Renderer>().enabled = false;
      PinkyTip.GetComponent<Renderer>().enabled = false;
      RingDistalJoint.GetComponent<Renderer>().enabled = false;
      RingKnuckle.GetComponent<Renderer>().enabled = false;
      RingMetacarpal.GetComponent<Renderer>().enabled = false;
      RingMiddleJoint.GetComponent<Renderer>().enabled = false;
      RingTip.GetComponent<Renderer>().enabled = false;
      ThumbDistalJoint.GetComponent<Renderer>().enabled = false;
      ThumbMetacarpalJoint.GetComponent<Renderer>().enabled = false;
      ThumbProximalJoint.GetComponent<Renderer>().enabled = false;
      ThumbTip.GetComponent<Renderer>().enabled = false;
      Wrist.GetComponent<Renderer>().enabled = false;

      //Hiding Prefabs
      LIndexDistalJoint.GetComponent<Renderer>().enabled = false;
      LIndexKnuckle.GetComponent<Renderer>().enabled = false;
      LIndexMetacarpal.GetComponent<Renderer>().enabled = false;
      LIndexMiddleJoint.GetComponent<Renderer>().enabled = false;
      LIndexTip.GetComponent<Renderer>().enabled = false;
      LMiddleDistalJoint.GetComponent<Renderer>().enabled = false;
      LMiddleKnuckle.GetComponent<Renderer>().enabled = false;
      LMiddleMetacarpal.GetComponent<Renderer>().enabled = false;
      LMiddleMiddleJoint.GetComponent<Renderer>().enabled = false;
      LMiddleTip.GetComponent<Renderer>().enabled = false;
      LPalm.GetComponent<Renderer>().enabled = false;
      LPinkyDistalJoint.GetComponent<Renderer>().enabled = false;
      LPinkyKnuckle.GetComponent<Renderer>().enabled = false;
      LPinkyMetacarpal.GetComponent<Renderer>().enabled = false;
      LPinkyMiddleJoint.GetComponent<Renderer>().enabled = false;
      LPinkyTip.GetComponent<Renderer>().enabled = false;
      LRingDistalJoint.GetComponent<Renderer>().enabled = false;
      LRingKnuckle.GetComponent<Renderer>().enabled = false;
      LRingMetacarpal.GetComponent<Renderer>().enabled = false;
      LRingMiddleJoint.GetComponent<Renderer>().enabled = false;
      LRingTip.GetComponent<Renderer>().enabled = false;
      LThumbDistalJoint.GetComponent<Renderer>().enabled = false;
      LThumbMetacarpalJoint.GetComponent<Renderer>().enabled = false;
      LThumbProximalJoint.GetComponent<Renderer>().enabled = false;
      LThumbTip.GetComponent<Renderer>().enabled = false;
      LWrist.GetComponent<Renderer>().enabled = false;

      //Main Cheese of the App

      Calibrate();

      if (calibraton) {
         
         //Right
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexDistalJoint, Handedness.Right, out virtualHand)) {
            Function(IndexDistalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexKnuckle, Handedness.Right, out virtualHand)) {
            Function(IndexKnuckle, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMetacarpal, Handedness.Right, out virtualHand)) {
            Function(IndexMetacarpal, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMiddleJoint, Handedness.Right, out virtualHand)) {
            Function(IndexMiddleJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out virtualHand)) {
            Function(IndexTip, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleDistalJoint, Handedness.Right, out virtualHand)) {
            Function(MiddleDistalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleKnuckle, Handedness.Right, out virtualHand)) {
            Function(MiddleKnuckle, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMetacarpal, Handedness.Right, out virtualHand)) {
            Function(MiddleMetacarpal, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMiddleJoint, Handedness.Right, out virtualHand)) {
            Function(MiddleMiddleJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out virtualHand)) {
            Function(MiddleTip, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Right, out virtualHand)) {
            Function(Palm, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyDistalJoint, Handedness.Right, out virtualHand)) {
            Function(PinkyDistalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyKnuckle, Handedness.Right, out virtualHand)) {
            Function(PinkyKnuckle, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMetacarpal, Handedness.Right, out virtualHand)) {
            Function(PinkyMetacarpal, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMiddleJoint, Handedness.Right, out virtualHand)) {
            Function(PinkyMiddleJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out virtualHand)) {
            Function(PinkyTip, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingDistalJoint, Handedness.Right, out virtualHand)) {
            Function(RingDistalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingKnuckle, Handedness.Right, out virtualHand)) {
            Function(RingKnuckle, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMetacarpal, Handedness.Right, out virtualHand)) {
            Function(RingMetacarpal, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMiddleJoint, Handedness.Right, out virtualHand)) {
            Function(RingMiddleJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out virtualHand)) {
            Function(RingTip, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbDistalJoint, Handedness.Right, out virtualHand)) {
            Function(ThumbDistalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbMetacarpalJoint, Handedness.Right, out virtualHand)) {
            Function(ThumbMetacarpalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Right, out virtualHand)) {
            Function(ThumbProximalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out virtualHand)) {
            Function(ThumbTip, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Right, out virtualHand)) {
            Function(Wrist, virtualHand);
            float distance = Vector3.Distance(virtualHand.Position, Camera.main.transform.position);
            Positioning2(distance);

            Scaling();
            Draw();
         }


         //Left
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexDistalJoint, Handedness.Left, out virtualHand)) {
            Function(LIndexDistalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexKnuckle, Handedness.Left, out virtualHand)) {
            Function(LIndexKnuckle, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMetacarpal, Handedness.Left, out virtualHand)) {
            Function(LIndexMetacarpal, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexMiddleJoint, Handedness.Left, out virtualHand)) {
            Function(LIndexMiddleJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out virtualHand)) {
            Function(LIndexTip, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleDistalJoint, Handedness.Left, out virtualHand)) {
            Function(LMiddleDistalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleKnuckle, Handedness.Left, out virtualHand)) {
            Function(LMiddleKnuckle, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMetacarpal, Handedness.Left, out virtualHand)) {
            Function(LMiddleMetacarpal, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleMiddleJoint, Handedness.Left, out virtualHand)) {
            Function(LMiddleMiddleJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out virtualHand)) {
            Function(LMiddleTip, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Left, out virtualHand)) {
            Function(LPalm, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyDistalJoint, Handedness.Left, out virtualHand)) {
            Function(LPinkyDistalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyKnuckle, Handedness.Left, out virtualHand)) {
            Function(LPinkyKnuckle, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMetacarpal, Handedness.Left, out virtualHand)) {
            Function(LPinkyMetacarpal, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyMiddleJoint, Handedness.Left, out virtualHand)) {
            Function(LPinkyMiddleJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out virtualHand)) {
            Function(LPinkyTip, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingDistalJoint, Handedness.Left, out virtualHand)) {
            Function(LRingDistalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingKnuckle, Handedness.Left, out virtualHand)) {
            Function(LRingKnuckle, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMetacarpal, Handedness.Left, out virtualHand)) {
            Function(LRingMetacarpal, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMiddleJoint, Handedness.Left, out virtualHand)) {
            Function(LRingMiddleJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out virtualHand)) {
            Function(LRingTip, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbDistalJoint, Handedness.Left, out virtualHand)) {
            Function(LThumbDistalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbMetacarpalJoint, Handedness.Left, out virtualHand)) {
            Function(LThumbMetacarpalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Left, out virtualHand)) {
            Function(LThumbProximalJoint, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out virtualHand)) {
            Function(LThumbTip, virtualHand);
         }
         if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Left, out virtualHand)) {
            Function(LWrist, virtualHand);

            float distance = Vector3.Distance(virtualHand.Position, Camera.main.transform.position);
            Positioning(distance);
            Scaling();
         }
      }
      //Yeah !!! that was a Lot
   }


   void Positioning(float distance) {

      //positioning
      GameObject line = GameObject.Find("Left_ShellHandRayPointer(Clone)");
      parent.transform.position += line.transform.forward * shift;

      //Shift
      if (rateControl)
         Shifting(distance);

      //Position Control Shift
      if (positionControl)
         PositionControl(extend, shrink);
   }

   void Positioning2(float distance) {

      //positioning
      GameObject line = GameObject.Find("Right_ShellHandRayPointer(Clone)");
      parent2.transform.position +=  line.transform.forward * shift;

      //Shift
      if (rateControl)
         Shifting(distance);

      //Position Control Shift
      if (positionControl)
         PositionControl(extend, shrink);
   }

   void Shifting(float distance) {

      //Shift
      if (distance > extend) {
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
      //scaling
      if (scaleControl) {
         if (current != shift) {
            float scalefactorGrow = parent2.transform.lossyScale.x + 0.01f;
            float scalefactorShrink = parent2.transform.lossyScale.x - 0.01f;


            Debug.Log(scalefactorGrow);

            // increase size
            if ((current < shift) && scalefactorGrow < 5) {
               parent.transform.localScale = new Vector3(scalefactorGrow, scalefactorGrow, scalefactorGrow);
               parent2.transform.localScale = new Vector3(scalefactorGrow, scalefactorGrow, scalefactorGrow);
            }

            //decrease size 
            if (current > shift) {
               parent.transform.localScale = new Vector3(scalefactorShrink, scalefactorShrink, scalefactorShrink);
               parent2.transform.localScale = new Vector3(scalefactorGrow, scalefactorGrow, scalefactorGrow);
            }

            if (shift < 1) {
               parent.transform.localScale = new Vector3(1f, 1f, 1f);
               parent2.transform.localScale = new Vector3(1f, 1f, 1f);
            }

            current = shift;
         }
      }
   }


   void Function(GameObject palmObject, MixedRealityPose virtualHand) {

      Vector3 pos = virtualHand.Position;
      palmObject.transform.position = pos;

      palmObject.GetComponent<Renderer>().enabled = true;
   }


   void Draw() {
      if (IsPinching()) {
         Destroy(Instantiate(marker4, IndexTip.transform.position, Quaternion.identity), 20);
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
      shift = 0f;

      return HandPoseUtils.CalculateIndexPinch(Handedness.Left) > pinchThreshold;
   }

   bool IsPinching() {
      float pinchThreshold = 0.7f;
      return HandPoseUtils.CalculateIndexPinch(Handedness.Right) > pinchThreshold;
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

            Debug.Log("extend: " + extend);
            Debug.Log("shrink: " + shrink);
            Debug.Log("Calibration Sucess");
            calibraton = true;
         }
      }
   }
}