using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class HitTarget : MonoBehaviour, IHittable
{
    [SerializeField] int hitScoreValue = 1;
    [SerializeField] int destroyScoreValue = 5;

    [SerializeField] protected TextMeshProUGUI hitScoreGainUI;
    [SerializeField] protected TextMeshProUGUI destroyScoreGainUI;


    private void Start()
    {
        ResetHitScoreUI();
        ResetDestroyScoreUI();
    }

    private void ResetDestroyScoreUI()
    {
        destroyScoreGainUI.text = "";
    }

    private void ResetHitScoreUI()
    {
        hitScoreGainUI.text = "";
    }


    private int CalculateHitScore()
    {
        return hitScoreValue;
    }
    public void TakeHit()
    {
        GainHitScore();
        Invoke(nameof(ResetHitScoreUI), 0.5f);
    }

    void GainHitScore()
    {
        hitScoreGainUI.text = "+" + CalculateHitScore().ToString();
    }
    public void GainDestroyScore()
    {
        destroyScoreGainUI.text= "+" + destroyScoreValue.ToString();
    }
}
