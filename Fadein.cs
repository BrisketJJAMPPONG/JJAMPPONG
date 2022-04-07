using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour
{
    GameObject FadeObj;
    Image Fadeimage;
    private bool checkbool = false;
    // Start is called before the first frame update
    void Start()
    {
        FadeObj = this.gameObject;
        Fadeimage = FadeObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("MainSplash");             //코루틴    //판넬 투명도 조절
        if (checkbool)
        {
            Destroy(this.gameObject);           //판넬 파괴, 삭제
        }

    }     //만약 checkbool 이 참이면
    IEnumerator MainSplash()
    {
        Color color = Fadeimage.color;                            //color 에 판넬 이미지 참조
        for (int i = 100; i >= 0; i--)                            //for문 100번 반복 0보다 작을 때 까지
        {
            color.a -= Time.deltaTime * 0.01f;               //이미지 알파 값을 타임 델타 값 * 0.01
            Fadeimage.color = color;                                //판넬 이미지 컬러에 바뀐 알파값 참조
            if (Fadeimage.color.a <= 0)                        //만약 판넬 이미지 알파 값이 0보다 작으면
            {
                checkbool = true;                              //checkbool 참 
            }
        }
        yield return null;                                        //코루틴 종료
    }
}
