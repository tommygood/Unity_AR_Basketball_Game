using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{
    public GameObject child_obj;
    
    public GameObject to_place;
    
    public ARRaycastManager ray_mana;
    
    public bool use_cursor = true;
    
    private bool put_rim = false;
    
    void Start() {
        child_obj.SetActive(use_cursor);
    }
    
    void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !put_rim) { // it is restart to touch screen, instead of holding screen
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            ray_mana.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
            if (hits.Count > 0) {
                GameObject.Instantiate(to_place, hits[0].pose.position, hits[0].pose.rotation);
                put_rim = true;
            }
        }
    }
}
