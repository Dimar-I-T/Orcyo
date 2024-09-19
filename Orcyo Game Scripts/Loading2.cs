using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading2 : MonoBehaviour
{

    public GameObject loadingBar;
    public Text persetageText;

    public void Keluar(int Index)
    {
        StartCoroutine(Loading(Index));
    }

    IEnumerator Loading(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadingBar.SetActive(true);
            persetageText.text = (progress * 100f).ToString("F0") + "%";

            yield return null;
        }
    }
}
