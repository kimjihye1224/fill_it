using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveConveyor : MonoBehaviour
{
    //level�� ���� �����̾Ʈ�� �ӵ��� �޶����� �����̾Ʈ �̵��ڵ�
    public int level = 1;
    public float t;
    public TextMeshProUGUI levelText;

    public Vector2 scrollSpeed;
    public Renderer beltRender;
    public static bool move = true;
    public GameObject confetii;
    public AudioClip levelupS;
    public AudioSource aud;

    // Start is called before the first frame update
    void Start()//���Ƿ� �� ������ 40�ʶ�� ������.
    {
        doll.speed = -0.04f;
        t = 40.0f;
        beltRender = GetComponent<Renderer>();
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�����̾Ʈ �̵� ȿ��
        if (t > 0)
        {
            t -= Time.deltaTime;
            if (move)
            {
                Vector2 offset = Time.time * scrollSpeed;
                beltRender.material.SetTextureOffset("_MainTex", offset);
            }

        }
        else
        {
            Debug.Log("40������");
            t = 40.0f;
            level += 1;
            biggerLevelUp.idx = 4;
            scrollSpeed.x += 0.01f;
            doll.speed -= 0.015f;
            dollGenerate.ratio += 1;
            levelText.text = level.ToString();
            confetii.GetComponent<ParticleSystem>().Play();
            this.aud.PlayOneShot(this.levelupS);
        }

    }

}