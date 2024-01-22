using System.Collections;
using UnityEngine;
using TMPro;

/// <summary>
/// This runs a countup timer that never stops
/// </summary>
public class ChangingValuesCoroutine : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countText;

    private void Start()
    {
        StartCoroutine("RunTimer");
        //StartCoroutine(RunTimer(1));
    }

   /* IEnumerator RunTimer(float countTime) 
    {
        int count= 0;
        while(true)
        {
            yield return new WaitForSeconds(countTime);
            count++;
            countText.text = count.ToString();
            Debug.Log("I am runnig");
        }
    }*/

    IEnumerator RunTimer()
    {
        int count = 0;
        while (true)
        {
            yield return new WaitForSeconds(1);
            count++;
            countText.text = count.ToString();
            Debug.Log("I am runnig");
        }

        Debug.Log("Timer ended");
    }
}
