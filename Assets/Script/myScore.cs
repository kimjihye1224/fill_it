using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myScore : MonoBehaviour
{
    public static int storedScore;

    public static myScore instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    public void storeScore(int s)
    {
        storedScore = s;
    }
}
