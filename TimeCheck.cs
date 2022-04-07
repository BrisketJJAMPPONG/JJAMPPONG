using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;


public class TimeCheck : MonoBehaviour
{


    [SerializeField]
    Text secWorm;
    public GameObject[] Pot;
    Text Wormtext;
    public int PotNum;
    public string url = "";
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("TimeGold", 1f,1f);
        StartCoroutine(WebChk());
        Wormtext = GameObject.Find("TimeWorm").GetComponent<Text>();
        Wormtext.text = "";
    }
    IEnumerator WebChk()
    {
        UnityWebRequest request = new UnityWebRequest();
        using (request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result ==UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError) //서버와의 통신중 오류 발생시
            {
                Debug.Log(request.error);
            }
            else
            {
                string date = request.GetResponseHeader("date");

                DateTime dateTime = DateTime.Parse(date).ToUniversalTime();
                TimeSpan timestamp = dateTime - new DateTime(1970, 1, 1, 0, 0, 0);

                int stopwatch =
                    (int)timestamp.TotalSeconds -
                    PlayerPrefs.GetInt("net", (int)timestamp.TotalSeconds);


                Debug.Log(stopwatch + "sec");
                PlayerPrefs.SetInt("net", (int)timestamp.TotalSeconds);
                CountPot(stopwatch);
               
            }
        }
    }
    public void CountPot(int time)
    {
       
        Pot = GameObject.FindGameObjectsWithTag("Pot");
        PotManager.Instance.Money += (int)(time * Pot.Length * 0.1);
        Wormtext.text = "재접속 지렁이 보너스: +" + (int)(time * Pot.Length * 0.1);
        for (int i = 0; i < Pot.Length; i++)
        {
            PotNum = 0;
            PotNum++;

        }
        StartCoroutine(Disabled(5.0f, Wormtext));
    }
    IEnumerator Disabled(float waitTime, Text txt)
    {
        yield return new WaitForSeconds(waitTime);
        txt.text = "";
    }
    void TimeGold()//시간당 지렁이
    {
        Pot = GameObject.FindGameObjectsWithTag("Pot");
        int Lerp;
        if (Pot.Length <= 3)
        {
            Lerp = 1;
        }
        else if (Pot.Length > 3 && Pot.Length <= 8)
        {
            Lerp = Pot.Length * 7;
        }
        else
        {
            Lerp = Pot.Length * 20;
        }
        
        PotManager.Instance.Money += Pot.Length * Lerp;
        secWorm.text = "초당 지렁이 + " + (Pot.Length * Lerp).ToString();


    }

}
