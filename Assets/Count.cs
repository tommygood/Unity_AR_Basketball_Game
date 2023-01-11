using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour {
    
    public int score = 0;
    
    public Text score_text;
    
    void Update()
    {
        score_text.text = score.ToString();
    }
}
