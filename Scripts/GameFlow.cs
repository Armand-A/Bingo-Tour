using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static GameFlow GF;

    public GameObject scratch1, scratch2, scratch3, wrongAlarm;
    
    public AudioSource scratchSFX, wrongSFX;

    TapHandler tap_s1, tap_s2, tap_s3;

    Animator anmtr_s1, anmtr_s2, anmtr_s3, anmtr_wrong;
    
    public int state = 0;

    public bool canClickCTA;

    // Start is called before the first frame update
    void Start()
    {
        GF = this; 

        tap_s1 = scratch1.GetComponent<TapHandler>();
        tap_s2 = scratch2.GetComponent<TapHandler>();
        tap_s3 = scratch3.GetComponent<TapHandler>();

        anmtr_s1 = scratch1.GetComponent<Animator>();
        anmtr_s2 = scratch2.GetComponent<Animator>();
        anmtr_s3 = scratch3.GetComponent<Animator>();
        anmtr_wrong = wrongAlarm.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Vector2 c = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (canClickCTA){
                Luna.Unity.Playable.InstallFullGame();
            } else if (state == 1 && tap_s1.checkTouch(c)){
                anmtr_s1.Play("16PinkScratch", 0, 0);
                scratchSFX.Play();
                state = 2;
            } else if (state == 3 && tap_s2.checkTouch(c)){
                anmtr_s2.Play("7RedScratch", 0, 0);
                scratchSFX.Play();
                state = 4;
            } else if (state == 5 && tap_s3.checkTouch(c)){
                anmtr_s3.Play("40GreenScratch", 0, 0);
                scratchSFX.Play();
                state = 6;
            } else { 
                /*if (!wrongAlarm.active){
                    wrongAlarm.SetActive(true);
                }
                anmtr_wrong.Play("Win_Light", 0, 0);*/
                wrongSFX.Play();
            }
        }
    }
}
