using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Click : MonoBehaviour
{

    AudioSource audio;

    AudioClip audioclip;
    [SerializeField]
    Text moneyText;
    Animator anim;
    public Text txt;
    public int Money;
    private void Start()
    {
        audio = GameObject.Find("ClickAudio").GetComponent<AudioSource>();
        audioclip = audio.clip;
        txt.text = "";
        anim = GetComponent<Animator>();
    }
   public void OnMouseDown()
    {
        audio.PlayOneShot(audioclip);
        anim.SetBool("Click", true);
        MoneyIncrease(Money);


    }
    private void OnMouseUp()
    {
        anim.SetBool("Click", false);
    }

    public void MoneyIncrease(int Gold)
    {

        PotManager.Instance.Money += Gold;
    }

}
