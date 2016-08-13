using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MyEvent : MonoBehaviour {
    //public MouseLook MyMouseLook;
    public void Exit()
    {
        Application.Quit();
    }
    public void Back()
    {
        Time.timeScale = 1.0f;
        SceneManager.UnloadScene(Application.loadedLevel);
        SceneManager.LoadScene("UI");
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
