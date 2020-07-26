using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public CanvasGroup grid;
    public CanvasGroup endGroup;
    public CanvasGroup about;
    public CanvasGroup win;
    private Animator transitionAnim;
    public GameObject knight;
    public GameObject knight1;
    // Start is called before the first frame update
    public bool hasStarted;
    void Start()
    {
        transitionAnim = GetComponent<Animator>();
        endGroup.alpha = 0f;
        endGroup.blocksRaycasts = false;
        about.alpha = 0f;
        about.blocksRaycasts = false;
        win.alpha = 0f;
        win.blocksRaycasts = false;

    }
    public void LoadScene(string sceneName)
    {
        hasStarted = true;
        StartCoroutine(Transition(sceneName));
    }
    IEnumerator Transition(string sceneName)
    {
        if (sceneName!= "Start" && sceneName != "Restart" && sceneName !="About" && sceneName != "GoBack") { 
            win.alpha = 1f;
            win.blocksRaycasts = true;
            transitionAnim.SetTrigger("end");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(sceneName);
            
        }else if(sceneName == "Restart"){
            if (knight == null)
            {
                knight = knight1;
            }
            win.alpha = 0f;
            win.blocksRaycasts = false;
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            grid.alpha = 0f;
            grid.blocksRaycasts = false;
            endGroup.alpha = 0f;
            endGroup.blocksRaycasts = false;
            GameObject spawner = GameObject.Find("WaveSpawner");
            spawner.GetComponent<WaveSpawner>().currentWaveIndex = 0;
            knight.GetComponent<knight>().health = 5;
            knight.GetComponent<knight>().UpdateHealthUI(5);
        }
        else if (sceneName == "About")
        {
            about.alpha = 1f;
            about.blocksRaycasts = true;
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
        }
        else if (sceneName == "GoBack")
        {
            about.alpha = 0f;
            about.blocksRaycasts = false;
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            GameObject spawner = GameObject.Find("WaveSpawner");
            spawner.GetComponent<WaveSpawner>().hasStarted = true;
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
            grid.alpha = 1f;
            grid.blocksRaycasts = true;
        }
        
    }
    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
