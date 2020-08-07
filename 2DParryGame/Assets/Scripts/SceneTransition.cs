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
    public CanvasGroup setting;
    private Animator transitionAnim;
    public GameObject knight;
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
        setting.alpha = 0f;
        setting.blocksRaycasts = false;
    }
    public void LoadScene(string sceneName)
    {
        hasStarted = true;
        StartCoroutine(Transition(sceneName));
    }
    IEnumerator Transition(string sceneName)
    {
        if (sceneName!= "Start" && sceneName != "Restart" && sceneName !="About" && sceneName != "GoBack" && sceneName!="Setting") {
            win.alpha = 0f;
            win.blocksRaycasts = false;
            transitionAnim.SetTrigger("end");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(sceneName);
            
        }else if(sceneName == "Restart"){
            GameObject spawner = GameObject.Find("WaveSpawner");
            win.alpha = 0f;
            win.blocksRaycasts = false;
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                Destroy(enemy);
            }
            var weapons = GameObject.FindGameObjectsWithTag("Weapon");
            foreach (var weapon in weapons)
            {
                Destroy(weapon);
            }
            knight.SetActive(true);
            
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            grid.alpha = 0f;
            grid.blocksRaycasts = false;
            endGroup.alpha = 0f;
            endGroup.blocksRaycasts = false;
            spawner.GetComponent<WaveSpawner>().currentWaveIndex = 0;
            spawner.GetComponent<WaveSpawner>().hasStarted = false;
            spawner.GetComponent<WaveSpawner>().finishedSpawning = false;
            knight.GetComponent<knight>().health = 3;
            knight.GetComponent<knight>().UpdateHealthUI(3);
        }
        else if (sceneName == "About")
        {
            about.alpha = 1f;
            about.blocksRaycasts = true;
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
        }
        else if (sceneName == "Setting")
        {
            setting.alpha = 1f;
            setting.blocksRaycasts = true;
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
        }
        else if (sceneName == "GoBack")
        {
            about.alpha = 0f;
            about.blocksRaycasts = false;
            setting.alpha = 0f;
            setting.blocksRaycasts = false;
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                Destroy(enemy);
            }
            var weapons = GameObject.FindGameObjectsWithTag("Weapon");
            foreach (var weapon in weapons)
            {
                Destroy(weapon);
            }
            GameObject spawner = GameObject.Find("WaveSpawner");
            
            knight.SetActive(true);
            knight.GetComponent<knight>().health = 3;
            knight.GetComponent<knight>().UpdateHealthUI(3);
            //GameObject spawner = GameObject.Find("WaveSpawner");
            spawner.GetComponent<WaveSpawner>().currentWaveIndex = 0;
            spawner.GetComponent<WaveSpawner>().finishedSpawning = false;
            //spawner.GetComponent<WaveSpawner>().emptyWave();
            spawner.GetComponent<WaveSpawner>().hasStarted = true;
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
            grid.alpha = 1f;
            grid.blocksRaycasts = true;
            win.alpha = 0f;
            win.blocksRaycasts = false;
            endGroup.alpha = 0f;
            endGroup.blocksRaycasts = false;
        }
        
    }
    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
