using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Main_Menu : MonoBehaviour {
    public GameObject Loading_image;
    public GameObject Main_Menu_Sprite;
    public UI2DSprite Main_Sprite;
    private float Myfloat;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject About_Sprite;
    public Texture2D Cursor_image;
    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.SetCursor(Cursor_image, Vector2.zero, CursorMode.Auto);
    }
	
	// Update is called once per frame
	void Update () {
        //Main_Sprite.alpha = Myfloat;
    }

    IEnumerator DisplayLoadingScreen()
    {////(1)
        Button1.SetActive(false);
        //Button2.SetActive(false);
        Button3.SetActive(false);
        //DOTween.To(() => Main_Sprite.alpha, x => Main_Sprite.alpha = x, 0, 3);
        //yield return new WaitForSeconds(3);
        Loading_image.SetActive(true);
        yield return new WaitForSeconds(35);
        AsyncOperation async = SceneManager.LoadSceneAsync("Scene");////(2)
        
        while (!async.isDone)
        {////(3)
            yield return null;
        }
    }

    public void Start_Game()
    {
        StartCoroutine(DisplayLoadingScreen());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void About()
    {
        About_Sprite.SetActive(true);
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Button4.SetActive(true);
    }
    public void Back()
    {
        About_Sprite.SetActive(false);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        Button4.SetActive(false);

    }
}
