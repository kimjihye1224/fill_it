using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class biggerAnimation : MonoBehaviour
{
    //fantastic, good, miss 등의 수식어구가 나올때 잠깐 커졌다가 사라지는 효과 주기위한 script
    float time = 0.0f;
    float time2 = 0.0f;
    Color tempcolor;
    Color tempcolor2;
    public List<Texture> wordTextures = new List<Texture>();
    public TextMeshProUGUI comboText;
    public GameObject comboGm;
    public static bool iscombo = false;
    public static int idx;
    public static int combo = 0;
    public GameObject obj;
    private RawImage image;
    //public bool onActive = true;

    void Start()
    {
        comboGm.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(combo >= 2 && iscombo == true)
        {
            comboText.text = combo.ToString();
            comboGm.SetActive(true);
            time2 += Time.deltaTime;
            tempcolor2 = comboText.color;
            tempcolor2.a = 1.0f;
            if(time2 > 0.4f)
            {
                comboGm.SetActive(false);
                time2 = 0.0f;
                iscombo = false;
            }
        }
        if(idx > 1)
        {
            combo = 0;
        }
        if(idx > 0)
        {
            image = obj.GetComponent<RawImage>();
            image.texture = wordTextures[idx - 1];
            //image = wordObjects[idx - 1].GetComponent<RawImage>();
            tempcolor = image.color;
            tempcolor.a = 1.0f;
            image.color = tempcolor;
            obj.transform.localScale = Vector3.one * (1 + time);
            time += Time.deltaTime;
            if (time > 0.4f)
            {
                time = 0.0f;
                tempcolor.a = 0.0f;
                image.color = tempcolor;
                idx = 0;
            }
        }
    }
}
