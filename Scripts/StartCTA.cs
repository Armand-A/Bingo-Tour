using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCTA : MonoBehaviour
{
    public GameObject cta, group;
    public void FinishAnimCTA(){
        cta.SetActive(true);
        group.SetActive(false);
        GameFlow.GF.canClickCTA = true;
    }
}
