using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detect : MonoBehaviour {
    
    public Count score_text;
        
    void OnTriggerEnter(Collider other) {
        if (other.tag == "ball")
            score_text.score += 1;
    }
}
