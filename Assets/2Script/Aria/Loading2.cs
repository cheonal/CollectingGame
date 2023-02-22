using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Loading2 : MonoBehaviour
{
    [SerializeField] CanvasGroup Fadeimg;
    float fadeDuration = 0.3f; //암전시간

    [SerializeField] GameObject Loadimg;

    [SerializeField] GameObject PurpleStar;

    public static Loading2 Instance
    {
        get
        {
            return instance;
        }
    }
    private static Loading2 instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Fadeimg.DOFade(0, fadeDuration)
            .OnStart(() => {
                Loadimg.SetActive(false);
            })
            .OnComplete(() => {
                Fadeimg.blocksRaycasts = false;
            });
    }

    public void ChangeScene(string sceneName)
    {
        Fadeimg.DOFade(1, fadeDuration)
            .OnStart(() => {
                Fadeimg.blocksRaycasts = true;
            })
            .OnComplete(() => {
                StartCoroutine("LoadScene", sceneName);
            });
    }

    IEnumerator LoadScene(string sceneName)
    {
        //Loadimg.SetActive(true);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        float past_time = 0;
        float percentage = 0;

        while (!(async.isDone))
        {
            yield return null;

            past_time += Time.deltaTime;

            if (percentage >= 90)
            {
                percentage = Mathf.Lerp(percentage, 100, past_time);

                if (percentage == 100)
                {
                    async.allowSceneActivation = true;
                }
            }

            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if (percentage >= 90) past_time = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        PurpleStar.transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime);
    }
}
