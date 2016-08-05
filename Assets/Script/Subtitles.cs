using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Subtitles : MonoBehaviour
{

    private bool Closeflag = true;
    bool begin = false;
    public string flag;
    public Texture tex;
    public Font myFont;
    public Text myText;
    public GameObject UI;
    public void Close()
    {
        Closeflag = true;
    }
    public void Show(string str)
    {
        Closeflag = false;
        begin = true;
        flag = "<color=#4E4E52>"+str+"</color>";
    }

    void Update()
    {
        if (!Closeflag && !UI.activeSelf)
        {
            UI.SetActive(true);
            myText.text = flag;
        }
        if (Closeflag && UI.activeSelf)
        {
            UI.SetActive(false);
        }
        if (myText.text != flag) myText.text = flag;
    }

/*    public void OnGUI()
    {
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = 24;
        GUI.skin.label.font = myFont;
        
        

        if (begin && !Closeflag)
        {
            GUI.Label(new Rect(Screen.width * 0.50f - 200, Screen.height * 0.15f - 120, Screen.width * 0.4f + 160, Screen.height * 0.5f), tex);

            GUI.Label(new Rect(Screen.width * 0.66f-120, Screen.height * 0.02f+25, Screen.width * 0.075f, Screen.height * 0.4f), flag);
            

        }
        
    }
*/


}