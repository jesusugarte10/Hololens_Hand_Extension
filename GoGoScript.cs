using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGoScript : MonoBehaviour
{
    private GameObject userHead;
    public GameObject realHand;
    public GameObject virtualHand;
    private GameObject minObject;
    private GameObject maxObject;

    public float handMinDist;
    public float handMaxDist;
    public float D;
    public float K;

    private float zValue;
    public float expRate;
    public Vector3 offset;

    public Material myMaterial;
    //public float yValue
    void Start()
    {
        virtualHand = GameObject.Instantiate(realHand,realHand.transform.position + offset,realHand.transform.rotation);
        virtualHand.GetComponent<Renderer>().material.color = myMaterial.color;
        handMinDist = realHand.transform.position.z;
        handMaxDist = realHand.transform.position.z + 0.55f;
        minObject = GameObject.Instantiate(realHand, realHand.transform.position, realHand.transform.rotation);
        minObject.GetComponent<Renderer>().material.color = Color.green;
        maxObject = GameObject.Instantiate(realHand, new Vector3 (realHand.transform.position.x, realHand.transform.position.y,handMaxDist), realHand.transform.rotation);
        maxObject.transform.localScale = maxObject.transform.localScale;
        maxObject.GetComponent<Renderer>().material.color = Color.green;
        //D = (2 * handMaxDist)/3;
        //K = 1 / D;
    }


    void Update()
    {

        //moving the "real" hand game object using the arrow keys
        //Debug.Log(realHand.transform.position);
        zValue = Input.GetAxis("Vertical");
        //realHand.transform.position += new Vector3(realHand.transform.position.x,realHand.transform.position.y,zValue*Time.deltaTime);
        realHand.transform.Translate(0, 0, zValue * Time.deltaTime);
        
        
        
        
        
        if (realHand.transform.position.z < D) {
            virtualHand.transform.position = realHand.transform.position + offset;
        }
        else {
            expRate = K * Mathf.Pow((realHand.transform.position.z*100 - D*100), 2);
            virtualHand.transform.position = (realHand.transform.position*100 +  expRate * transform.forward + offset)/100;
        }
        

    }
}
