using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class doll : MonoBehaviour
{
    public GameObject coin;
    public GameObject coinParticle;
    public GameObject cotton;
    public GameObject bugFX;
    public static float speed; //인형 초기 스피드
    dollGenerate dG;
    private Animator animator;
    private bool touch = false; //bug인형과 솜 기계 점수 차감 한번만
    public AudioClip bugS;
    public AudioClip missS;
    public AudioClip goodS;
    public AudioClip fantasticS;
    public AudioSource aud;

    public static bool heart = false;

    public GameObject SliderPrefab;
    //public Vector3 guageOffset = new Vector3(0, 10.2f, 0);
    private Canvas guageCanvas;
    private Image BarImage;
    private GameObject guages;
    private SliderController _guage;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.CompareTag("bear"))
        {
            this.transform.Rotate(0, -90, 0, Space.World);
        }
        if (this.gameObject.CompareTag("bug"))
        {
            this.transform.position = new Vector3(-0.09f, -1.7f, 27.5f);
            this.transform.Rotate(-90, 90, 0, Space.World);
        }
        animator = GetComponent<Animator>();
        dG = GameObject.Find("conveyorBelt").GetComponent<dollGenerate>();
        this.aud = GetComponent<AudioSource>();

        setGuage();
    }

    // Update is called once per frame
    void Update()
    {
        //컨베이어 벨트가 움직이면 인형도 움직임
        if (MoveConveyor.move)
        {
            this.transform.position += new Vector3(0, 0, speed);
        }
        BarImage.fillAmount = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        //print(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }

    void setGuage()
    {
        guageCanvas = GameObject.Find("GuageCanvas").GetComponent<Canvas>();
        guages = Instantiate<GameObject>(SliderPrefab, guageCanvas.transform);
        BarImage = guages.GetComponentsInChildren<Image>()[1];  // bar 이미지 접근


        _guage = guages.GetComponent<SliderController>();
        _guage.targetTr = this.gameObject.transform;
        //_guage.offset = guageOffset;
        //Debug.Log("offset : " + _guage.offset);
    }

    private void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.name == "Cube")
        {
            _guage.DestroyGuage();
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("sidePunch")) //인형과 주먹기계가 충돌 시
        {
            /* transform.Translate(new Vector3(-4, -0.1f, 0));*/
            if (this.gameObject.CompareTag("bear")) //상황 1) 인형 - 주먹기계 충돌 시 miss (- 30)
            {
                heart = true;
                transform.Translate(new Vector3(4, -1f, 5));
                biggerAnimation.idx = 3;
                this.aud.PlayOneShot(this.missS);
            }
            else if (this.gameObject.CompareTag("bug")) // 상황 2) 불량품 - 주먹기계 충돌 시 fantastic (+ 50)
            {
            transform.Translate(new Vector3(4, 10f, 5f));//z는 양수
                gameController.score += 50;
                biggerAnimation.idx = 1;
                biggerAnimation.combo += 1;
                biggerAnimation.iscombo = true;
                this.aud.PlayOneShot(this.goodS);
            }
            _guage.DestroyGuage();
            Destroy(this.gameObject, 5f);
        }

        if (other.gameObject.CompareTag("floor"))
        {
            //_guage.DestroyGuage();
            Destroy(this.gameObject, 2f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.name == "generate")
        {
            dG.generate();
        }

        if (other.gameObject.name == "generate2")
        {
            if (this.gameObject.CompareTag("bear"))
            {
                
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Take 001 0") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.9f)
                { // 솜이 채워지기 시작하는 첫 애니메이션의 실행정도 감지. 1 이상일경우  첫번째 애니메이션 다 실행한 경우.
                    //gameController.score -= 30;
                    heart = true;
                    biggerAnimation.idx = 3;
                    this.aud.PlayOneShot(this.missS);
                }
                else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Take 001") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.1f)
                { // 다 채워진 두번째 애니메이션이 실행중일 경우. 즉 우리가 원하는 멀쩡한 상태의 경우.

                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f)//상황 4)인형에 적절한 솜이 들어간 경우 fantastic(+50)
                    {
                        coin.SetActive(true);
                        coinParticle.GetComponent<ParticleSystem>().Play();

                        gameController.score += 50;
                        biggerAnimation.idx = 1;
                        biggerAnimation.combo += 1;
                        biggerAnimation.iscombo = true;
                        this.aud.PlayOneShot(this.fantasticS);
                    }
                    else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f)//상황 5)인형에 솜이 덜 들어간 경우 good(+30)
                    {
                        gameController.score += 30;
                        biggerAnimation.idx = 2;
                        this.aud.PlayOneShot(this.goodS);
                    }
                    else//상황 6)인형에 솜이 너무 조금 들어간 경우 miss(-30)
                    {
                        // gameController.score -= 30;
                        heart = true;
                        biggerAnimation.idx = 3;
                        this.aud.PlayOneShot(this.missS);
                    }

                }
                else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Take 001 1"))
                {//상황 7) 인형에 솜이 너무 많이 들어간 경우 miss(-30)
                    heart = true;
                    biggerAnimation.idx = 3;
                    this.aud.PlayOneShot(this.missS);
                }

            }
            else //bug 인형일 때
            {//상황 8)불량품에 솜을 넣으려 했을 경우 miss (-30)
                heart = true;
                biggerAnimation.idx = 3;
                this.aud.PlayOneShot(this.missS);
            }

        }

        if (other.gameObject.name == "cottonmachine") //불량품과 솜기계가 충돌 시
        {
            if (this.gameObject.CompareTag("bug"))
            {
                if (!touch)
                {
                    heart = true;
                    //biggerAnimation.idx = 3;
                    //this.aud.PlayOneShot(this.missS);
                    bugFX.GetComponent<ParticleSystem>().Play();
                    touch = true;
                    /* Destroy(gameObject,0.5f);*/
                }


            }

            // 파티클 재생, 이후 소멸. 

        }

        /*   scoreText.text = gameController.score.ToString();*/

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "cottonmachine")
        {
            if (this.gameObject.CompareTag("bear"))
            {
                animator.SetBool("IsFill", true);

                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
                {
                    animator.SetBool("IsPop", true);
                    cotton.GetComponent<ParticleSystem>().Play();
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "cottonmachine")
        {
            if (this.gameObject.CompareTag("bear"))
            {
                animator.enabled = false;

            }

            if (this.gameObject.CompareTag("bug"))
            {
                /*if (!touch)
                {*/
                this.aud.PlayOneShot(this.bugS);
                _guage.DestroyGuage();
                Destroy(gameObject, 0.1f);
                //}


            }
        }
    }
}
