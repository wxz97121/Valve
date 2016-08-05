using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SpecialInteractive : MonoBehaviour
{
    public bool done;
    public int need;
    public int now;
    private float Mytime;

    public string[] Ask;
    public int[] Yes;
    public int[] No;
    public int State;
    public int[] ID;
    private LastDay LD;
    private Subtitles SB;
    private GameObject Left, Right;
    private AudioSource newsAU;
    private AudioSource footstepsAU;
    private AudioSource supplyAU;
    private AudioSource ringAU;
    public Sprite hold;
    public Sprite unhold;
    private bool ani = false;
    public int Query(int n)
    {
        for (int i = 0; i < ID.Length; i++) if (ID[i] == n) return i;
        return 1000;
    }
    public IEnumerator First()
    {
        LD = GameObject.FindGameObjectWithTag("LD").GetComponent<LastDay>();
        newsAU = GameObject.FindGameObjectWithTag("news").GetComponent<AudioSource>();
        footstepsAU = GameObject.FindGameObjectWithTag("footstep").GetComponent<AudioSource>();
        supplyAU = GameObject.FindGameObjectWithTag("supply").GetComponent<AudioSource>();
        ringAU = GameObject.FindGameObjectWithTag("ring").GetComponent<AudioSource>();
        need = 1;
        SB = GameObject.FindGameObjectWithTag("SB").GetComponent<Subtitles>();
        done = false;
        now = 0;
        if (State == 1) if (LD.Query(40004)) State = 10007; else State = 10012;
        if (State == 2) if (LD.Query(20003)) State = 20006; else State = 20012;
        if (State == 3) if (LD.Query(50002)) State = 50004; else State = 50007;
        Left = GameObject.FindGameObjectWithTag("left");
        Right = GameObject.FindGameObjectWithTag("right");
        yield return new WaitForSeconds(1);
        SB.Show(Ask[Query(State)]);
        //显示气泡，Ask0[Display]
    }

    void leave()
    {
        LD.Append(State);
        done = true;
    }
    IEnumerator change()
    {
        yield return new WaitForSeconds(1.25f);
        Left.GetComponent<SpriteRenderer>().sprite = unhold;
        Left.transform.DORotate(new Vector3(0, 0, 0), 1f);
        Left.transform.DOMoveX(-730, 1f);
        yield return new WaitForSeconds(1);
        ani = false;
    }
    IEnumerator changeRight()
    {
        yield return new WaitForSeconds(0.8f);
        ani = false;
    }

    void Update()
    {
        if (ani) return;
        if (Input.GetKeyDown(KeyCode.A))
        {
            //胳膊 move rotate
            //Left.transform.DOMoveX(-450, 1);
            Left.transform.DORotate(new Vector3(0, 0, 35), 0.8f);
            Left.transform.DOMoveX(-930, 1);
            Mytime = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (Time.time - Mytime > 0.7f)
            {
                ani = true;
                Left.GetComponent<SpriteRenderer>().sprite = hold;
                Left.transform.DOMoveX(-530, 1.25f);
                Right.transform.DORotate(new Vector3(0, 0, 0), 0.8f);
                Right.transform.DOMoveX(681, 0.8f);
                StartCoroutine(change());
                //Left.transform.DOMoveX(-350, 0.75f);
                supplyAU.Play();
                GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController1>().have--;
                if (GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController1>().have <= 0) leave();
                //胳膊继续移动，给他一包粮食.
                //改变粮食图片
                now++;
                State = Yes[Query(State)];
                SB.Show(Ask[Query(State)]);
                if (Yes[Query(State)] == 0) leave();
            }
            else
            {
                Mytime = 100000;
                Left.transform.DORotate(new Vector3(0, 0, 0), 0.85f);
                Left.transform.DOMoveX(-730, 0.85f);
                //胳膊移动回去
            }
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            Right.transform.DORotate(new Vector3(0, 0, -35), 0.8f);
            Right.transform.DOMoveX(1100, 0.8f);
            //胳膊 move rotate
            Mytime = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (Time.time - Mytime > 0.7)
            {
                ani = true;
                ringAU.Play();
                //按铃并回去
                Right.transform.DORotate(new Vector3(0, 0, 0), 0.8f);
                Right.transform.DOMoveX(681, 0.8f);
                Left.transform.DORotate(new Vector3(0, 0, 0), 0.85f);
                Left.transform.DOMoveX(-730, 0.85f);
                StartCoroutine(changeRight());
                State = No[Query(State)];
                SB.Show(Ask[Query(State)]);
                if (No[Query(State)] == 0) leave();
            }
            else
            {
                Mytime = 100000;
                Right.transform.DORotate(new Vector3(0, 0, 0), 0.8f);
                Right.transform.DOMoveX(681, 0.8f);
                //胳膊移动回去
            }
        }

    }
}
