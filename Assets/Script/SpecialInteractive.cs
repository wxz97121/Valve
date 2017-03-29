using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;

public class SpecialInteractive : BasicInteractive
{
    public bool done;
    public int need;
    public int now;
    private float Mytime;

    /*  
        public string[] Ask;
        public int[] Yes;
        public int[] No;
        public int[] ID;
    */
    public SpecialDialogue myDia;
    public int State;
    private LastDay LD;
    public Sprite[] Emo;
    private SpriteRenderer myTag;
    public Sprite Tag;
    public int Query(int n)
    {
        for (int i = 0; i < myDia.ID.Length; i++)
            if (myDia.ID[i] == n) return i;
        return 1000;
    }                        
    public override IEnumerator Begin()
    {
        //ani = true;
        myTag = GameObject.FindGameObjectWithTag("Tag").GetComponent<SpriteRenderer>();
        myDia = GameObject.FindGameObjectWithTag("NSD").GetComponent<SpecialDialogue>();
        LD = GameObject.FindGameObjectWithTag("LD").GetComponent<LastDay>();
        //newsAU = GameObject.FindGameObjectWithTag("news").GetComponent<AudioSource>();
        //footstepsAU = GameObject.FindGameObjectWithTag("footstep").GetComponent<AudioSource>();
        //supplyAU = GameObject.FindGameObjectWithTag("supply").GetComponent<AudioSource>();
        //ringAU = GameObject.FindGameObjectWithTag("ring").GetComponent<AudioSource>();
        need = 1;
        SB = GameObject.FindGameObjectWithTag("SB").GetComponent<Subtitles>();
        done = false;
        now = 0;
        if (State == 1) if (LD.Query(40004)) State = 10007; else State = 10012;
        if (State == 2) if (LD.Query(20003)) State = 20006; else State = 20012;
        if (State == 3) if (LD.Query(50002)) State = 50004; else State = 50007;
        GetComponent<SpriteRenderer>().DOFade(255, 3);
        GetComponent<SpriteRenderer>().DOColor(Color.white, 2);
        Left = GameObject.FindGameObjectWithTag("left");
        Right = GameObject.FindGameObjectWithTag("right");
        myTag.sprite = Tag;
        myTag.DOColor(Color.white, 1);
        yield return new WaitForSeconds(1);
        SB.Show(myDia.Ask[Query(State)]);
        yield return new WaitForSeconds(2);
        myTag.DOColor(Color.clear, 1);
        GetComponent<SpriteRenderer>().sprite = Emo[myDia.Emo[Query(State)]];
        m_State = Ani_State.Wait;
        //显示气泡，Ask0[Display]
    }
    public override void LeftFunction()
    {
        supplyAU.Play();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController1>().have--;
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController1>().have <= 0) leave();
        //胳膊继续移动，给他一包粮食.
        //改变粮食图片
        now++;
        State = myDia.Yes[Query(State)];
        SB.Show(myDia.Ask[Query(State)]);
        GetComponent<SpriteRenderer>().sprite = Emo[myDia.Emo[Query(State)]];
        if (myDia.Yes[Query(State)] == 0) leave();
    }
    public override void RightFunction()
    {
        ringAU.Play();
        State = myDia.No[Query(State)];
        SB.Show(myDia.Ask[Query(State)]);
        GetComponent<SpriteRenderer>().sprite = Emo[myDia.Emo[Query(State)]];
        Mytime = 100000;
        if (myDia.No[Query(State)] == 0) leave();
    }
    void leave()
    {
        LD.Append(State);
        StartCoroutine(End());
    }
    //IEnumerator change()
    //{
    //    yield return new WaitForSeconds(1.25f);
    //    Left.GetComponent<SpriteRenderer>().sprite = unhold;
    //    Left.transform.DORotate(new Vector3(0, 0, 0), 1f);
    //    Left.transform.DOMoveX(-730, 1f);
    //    yield return new WaitForSeconds(1);
    //}
    //IEnumerator changeRight()
    //{
    //    yield return new WaitForSeconds(0.8f);
    //    ani = false;
    //}

    /*void Update()
    {
        if (ani || SB.doing) return;
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
                Mytime = 100000;
                State = myDia.Yes[Query(State)];
                SB.Show(myDia.Ask[Query(State)]);
                GetComponent<SpriteRenderer>().sprite = Emo[myDia.Emo[Query(State)]];
                if (myDia.Yes[Query(State)] == 0) leave();
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
                State = myDia.No[Query(State)];
                SB.Show(myDia.Ask[Query(State)]);
                GetComponent<SpriteRenderer>().sprite = Emo[myDia.Emo[Query(State)]];
                Mytime = 100000;
                if (myDia.No[Query(State)] == 0) leave();
            }
            else
            {
                Mytime = 100000;
                Right.transform.DORotate(new Vector3(0, 0, 0), 0.8f);
                Right.transform.DOMoveX(681, 0.8f);
                //胳膊移动回去
            }
        }

    }*/
}
