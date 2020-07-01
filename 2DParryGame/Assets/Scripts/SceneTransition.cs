using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public CanvasGroup grid;
    private Animator transitionAnim;
    // Start is called before the first frame update
    public bool hasStarted;
    void Start()
    {
        transitionAnim = GetComponent<Animator>();   
    }
    public void LoadScene(string sceneName)
    {
        hasStarted = true;
        StartCoroutine(Transition(sceneName));
    }
    IEnumerator Transition(string sceneName)
    {
        if (sceneName!= "Start") { 
            transitionAnim.SetTrigger("end");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(sceneName);
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
