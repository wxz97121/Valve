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
    public Texture2D Cursor_image;
    public GameObject Loading_text;
    public Sprite[] Loading_letter;
    public AudioSource BGM;
    private int State = -1;
    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.SetCursor(Cursor_image, Vector2.zero, CursorMode.Auto);
    }
	
	// Update is called once per frame
	void Update () {
        if (Loading_image.activeSelf == true && Input.GetKeyDown(KeyCode.Space))
        {
            State++;
            if (State >= Loading_letter.Length) Start_Game2();
            else Loading_image.GetComponent<UI2DSprite>().sprite2D = Loading_letter[State];
        }
            
        //Main_Sprite.alpha = Myfloat;
    }


    public void Start_Game2()
    {
        BGM.DOFade(0, 2);
        //SceneManager.LoadScene("Scene");
        AsyncOperation async = SceneManager.LoadSceneAsync("Scene");
        Loading_image.GetComponent<UI2DSprite>().color = Color.black;
        Loading_text.SetActive(true);
    } 

    public void Start_Game()
    {
        Button1.SetActive(false);
        //Button2.SetActive(true);
        Button3.SetActive(false);
        Loading_image.SetActive(true);
        BGM.DOFade(0.4f, 5);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
