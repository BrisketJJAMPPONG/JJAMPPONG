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
            txt.text = Pot.name + " ���Ű� �Ϸ�Ǿ����ϴ�.";
            StartCoroutine(Disabled(3.0f,txt));
            btn.interactable = false;

        }
        else
        {
            txt.text =" �����̰� �����Ͽ� ������ �� �����ϴ�.";
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
        Moneytxt.text = Money.ToString() + " ��"; 
    }
}
