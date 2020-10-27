using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{

    [SerializeField] private int sceneID;
    [SerializeField] private Slider loading;
    [SerializeField] private Text loadingText;

    private void Start()
    {

        loading = GetComponent<Slider>();

        sceneID = 1;
        StartCoroutine("Load");

    }

    IEnumerator Load()
    {

        AsyncOperation load = SceneManager.LoadSceneAsync(sceneID);

        while (!load.isDone)
        {
            loading.value = (float)load.progress / 0.9f;
            loadingText.text = loading.value + "%";
            yield return null;
        }

    }

}
