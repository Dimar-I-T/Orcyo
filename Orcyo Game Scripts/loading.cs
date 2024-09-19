using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loading : MonoBehaviour
{

    public Text textProgress;
    public GameObject loadingPanel;

    public void loadLevel1(int indexScene)
    {
        /*switch (totalscore.dataPemain.pilihanDifficulty)
        {
            // indexScene = SceneLevel
            // SceneLevel = LevelPoint + 1
            case 1:
                // kalo dia easy mode
                if (totalscore.dataPemain.levelPoint > 1) {
                    indexScene = totalscore.dataPemain.levelPoint + 1;
                }else if(totalscore.dataPemain.levelPoint < 0)
                {
                    // Have Ended All Levels
                    indexScene = 2;
                }
                break;
            case 2:
                // kalo dia hard mode
                /// SceneLevel = Lvl1 + 1
                /// SceneLevel = 1 + 1
                /// SceneLevel = 2
                indexScene = 2;
                break;
        }*/

        indexScene = 2;
        StartCoroutine(loadingProgress(indexScene)); 
        AudioONorOFF.Mute = false;
        AudioONorOFF.angka = 1;
        AudioONorOFF.angkaSementara = 1;
    }

    IEnumerator loadingProgress(int indexScene)
    {
        AsyncOperation proses = SceneManager.LoadSceneAsync(indexScene);
        
        while (!proses.isDone)
        {
            float angkaProses = Mathf.Clamp01(proses.progress / .9f);
            loadingPanel.SetActive(true);
            textProgress.text = (angkaProses * 100f).ToString("F0") + "%";

            yield return null;
        }
    }
}
