using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Subtitles : MonoBehaviour
{
    public bool doing = false;
    public string[] Fin;
    public Font myFont;
    public Text myText;
    public GameObject UI;
    public GameObject UI3_1;
    public GameObject UI3_2;
    public GameObject UI3_3;
    public GameObject UI2_1;
    public GameObject UI2_2;
    [SerializeField]
    private float WaitTime;
    public void Close()
    {
        UI.SetActive(false);
        UI2_1.SetActive(false);
        UI2_2.SetActive(false);
        UI3_1.SetActive(false);
        UI3_2.SetActive(false);
        UI3_3.SetActive(false);
    }
    IEnumerator ShowInOrder(string[] Fin)
    {
        if (Fin.Length == 1)
        {
            UI.SetActive(true);
            UI.GetComponentInChildren<Text>().text = Fin[0];
        }
        else if(Fin.Length==2)
        {
            UI2_1.SetActive(true);
            UI2_1.GetComponentInChildren<Text>().text = Fin[0];
            yield return new WaitForSeconds(WaitTime);
            UI2_2.SetActive(true);
            UI2_2.GetComponentInChildren<Text>().text = Fin[1];
        }
        else
        {
            UI3_1.SetActive(true);
            UI3_1.GetComponentInChildren<Text>().text = Fin[0];
            yield return new WaitForSeconds(WaitTime);
            UI3_2.SetActive(true);
            UI3_2.GetComponentInChildren<Text>().text = Fin[1];
            yield return new WaitForSeconds(WaitTime);
            UI3_3.SetActive(true);
            UI3_3.GetComponentInChildren<Text>().text = Fin[2];
        }
        doing = false;
    }
    public void Show(string str)
    {
        Close();
        doing = true;
        Fin = str.Split('|');
        for (int i=0;i<Fin.Length;i++) Fin[i] = "<color=#4E4E52>" + Fin[i] + "</color>";
        StartCoroutine(ShowInOrder(Fin));
    }

    /*    void Update()
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

        public void OnGUI()
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