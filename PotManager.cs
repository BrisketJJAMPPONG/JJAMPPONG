using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PotManager : MonoBehaviour
{
    public Text Moneytxt;
    Text purchaseText;
    private static PotManager instance = null;
    public int Money;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        purchaseText = GameObject.Find("Purchase_tex").GetComponent<Text>();
        purchaseText.text = "";
    }
    public static PotManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    public void PotCreate(GameObject Pot,Text txt ,int PotCost , Button btn)
    {
        
        if (Money >= PotCost)
        {
            Money -= PotCost;
            Pot.SetActive(true);
            txt.text = Pot.name + " 구매가 완료되었습니다.";
            StartCoroutine(Disabled(3.0f,txt));
            btn.interactable = false;

        }
        else
        {
            txt.text =" 지렁이가 부족하여 구매할 수 없습니다.";
            StartCoroutine(Disabled(3.0f, txt));
        }
    }
    IEnumerator Disabled(float waitTime,Text txt)
    {
        yield return new WaitForSeconds(waitTime);
        txt.text = "";
    }






    private void Update()
    {
        Moneytxt.text = Money.ToString() + " 개"; 
    }
}
