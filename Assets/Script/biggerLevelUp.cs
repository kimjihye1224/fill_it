using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class biggerLevelUp : MonoBehaviour
{
    //fantastic, good, miss ���� ���ľ�� ���ö� ��� Ŀ���ٰ� ������� ȿ�� �ֱ����� script
    float time = 0.0f;
    Color tempcolor;
    public Texture wordTexture;
    public static int idx;
    public GameObject obj;
    private RawImage image;
    //public bool onActive = true;

    // Update is called once per frame
    void Update()
    {
        if(idx == 4)
        {
            image = obj.GetComponent<RawImage>();
            image.texture = wordTexture;
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
