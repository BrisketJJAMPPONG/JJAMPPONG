using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotButton : MonoBehaviour
{

    public Button PotBtn;
    public Transform PotPos;
    public GameObject Pot;
    // Start is called before the first frame update
    void Start()
    {
       
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PotCre()
    {
        Pot.transform.position = PotPos.position;
    }
}
