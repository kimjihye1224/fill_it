using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverDirector : MonoBehaviour
{
    public Text sc;
    // Start is called before the first frame update
    void Start()
    {
        sc.text = myScore.storedScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
