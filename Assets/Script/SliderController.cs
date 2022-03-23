using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    private Canvas canvas;
    private Camera guageCamera;
    private RectTransform rectParent;
    private RectTransform rectGauage;

    public Vector3 offset;  // slider와 곰인형 사이 거리
    public Transform targetTr;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        guageCamera = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectGauage = this.gameObject.GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        // world좌표(3D) -> 2D
        //var screenPos = Camera.main.WorldToScreenPoint(targetTr.position + offset);
        var screenPos = Camera.main.WorldToScreenPoint(targetTr.position);

        //Debug.Log("offset : " + offset);
        /*if (screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
        }*/
        var localPos = Vector2.zero;  // 초기화
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, screenPos, guageCamera, out localPos);  // ScreenPoint -> Canvas point

        rectGauage.localPosition = localPos;  // 좌표설정
    }

    public void DestroyGuage()
    {
        Destroy(gameObject);
    }
}
