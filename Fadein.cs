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
        StartCoroutine("MainSplash");             //�ڷ�ƾ    //�ǳ� ���� ����
        if (checkbool)
        {
            Destroy(this.gameObject);           //�ǳ� �ı�, ����
        }

    }     //���� checkbool �� ���̸�
    IEnumerator MainSplash()
    {
        Color color = Fadeimage.color;                            //color �� �ǳ� �̹��� ����
        for (int i = 100; i >= 0; i--)                            //for�� 100�� �ݺ� 0���� ���� �� ����
        {
            color.a -= Time.deltaTime * 0.01f;               //�̹��� ���� ���� Ÿ�� ��Ÿ �� * 0.01
            Fadeimage.color = color;                                //�ǳ� �̹��� �÷��� �ٲ� ���İ� ����
            if (Fadeimage.color.a <= 0)                        //���� �ǳ� �̹��� ���� ���� 0���� ������
            {
                checkbool = true;                              //checkbool �� 
            }
        }
        yield return null;                                        //�ڷ�ƾ ����
    }
}
