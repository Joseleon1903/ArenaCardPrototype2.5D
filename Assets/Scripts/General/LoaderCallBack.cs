using Assets.Scripts.Logs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderCallBack : MonoBehaviour
{

    private bool IsFirstUpdate;

    [SerializeField]private Image imageFiller;

    [SerializeField] public float intervalo = 3f;

    [SerializeField] public String nextScene;

    private float IncrementerValue = 0.01f;



    // Start is called before the first frame update
    void Start()
    {
        IsFirstUpdate = true;
        imageFiller.fillAmount = 0;

        StartCoroutine(FillLoadingBar());

    }


    private IEnumerator FillLoadingBar()
    {


        while (IsFirstUpdate)
        {

            if (imageFiller.fillAmount == 1)
            {
                IsFirstUpdate = false;
                SceneManager.LoadScene(nextScene);
            }

            imageFiller.fillAmount += IncrementerValue;
            LoggerFile.Instance.INFO_LINE("incresed barr ++ ");
            yield return new WaitForSeconds(intervalo);
        }
    }

    public void IcreseBarValue(float value) {
        imageFiller.fillAmount += value;
    }

}
