using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PotCre : MonoBehaviour
{
    public int Cost;
    Text purchaseText;
    public GameObject CreatedPot;
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        purchaseText = GameObject.Find("Purchase_tex").GetComponent<Text>();

    }

    // Update is called once per frame

    public void Pot1Cre()
    {
        if (CreatedPot.activeSelf == false)
        {
            PotManager.Instance.PotCreate(CreatedPot, purchaseText, Cost , btn); 
            

        }
    
        

    }

}
