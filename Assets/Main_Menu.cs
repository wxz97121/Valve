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
    public GameObject About_Sprite;
    //public Texture2D Cursor_image;
    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Cursor.SetCursor(Cursor_image, Vector2.zero, CursorMode.Auto);
    }
	
	// Update is called once per frame
	void Update () {
        //Main_Sprite.alpha = Myfloat;
    }


    public void Start_Game2()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("Scene");
    } 

    public void Start_Game()
    {
        Button1.SetActive(false);
        Button2.SetActive(true);
        Button3.SetActive(false);
        Loading_image.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
