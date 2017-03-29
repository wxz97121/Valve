using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Interactive : BasicInteractive
{
    public int need;
    public float P;
    public int type;
    public int now;
    private float Mytime;
    string ask;
    string yes;
    string no;
    //private Subtitles SB;
    //private GameObject Left, Right;
    //private AudioSource newsAU;
    //private AudioSource footstepsAU;
    //private AudioSource supplyAU;
    //private AudioSource ringAU;
    //public Sprite hold;
    //public Sprite unhold;
    private int chapter;
    private NewDialogue ND;
    private RandomSprite RS;
    private SpriteRenderer myTag;
    public Sprite Tag;
    public override IEnumerator Begin()
    {
        RS = GameObject.FindGameObjectWithTag("RD").GetComponent<RandomSprite>();
        if (type==1)
        {
            int sprnum=Random.Range(0,RS.Farmer.Length);
            GetComponent<SpriteRenderer>().sprite = RS.Farmer[sprnum];
        }
        if (type == 2)
        {
            int sprnum = Random.Range(0, RS.Weaver.Length);
            GetComponent<SpriteRenderer>().sprite = RS.Weaver[sprnum];
        }
        if (type == 3)
        {
            int sprnum = Random.Range(0, RS.Worker.Length);
            GetComponent<SpriteRenderer>().sprite = RS.Worker[sprnum];
        }
        if (type == 4)
        {
            int sprnum = Random.Range(0, RS.Livestock.Length);
            GetComponent<SpriteRenderer>().sprite = RS.Livestock[sprnum];
        }
        myTag = GameObject.FindGameObjectWithTag("Tag").GetComponent<SpriteRenderer>();
        chapter = transform.parent.gameObject.name[7] - 48;
        ND = GameObject.FindGameObjectWithTag("ND").GetComponent<NewDialogue>();
        now = 0;
        //Display = (int)Random.Range(0,(Ask0.Length));
        //去找newDialogue获取一组
        ND.GetDialogue(chapter, 1, 1, type, ref ask, ref yes, ref no);
        GetComponent<SpriteRenderer>().DOFade(255, 3);
        GetComponent<SpriteRenderer>().DOColor(Color.white, 2);
        myTag.sprite = Tag;
        myTag.DOColor(Color.white, 1);
        yield return new WaitForSeconds(1);
        SB.Show(ask);
        yield return new WaitForSeconds(2);
        myTag.DOColor(Color.clear, 1);
        m_State = Ani_State.Wait;
        //显示气泡，A
    }
    public override void LeftFunction() 
    {
        supplyAU.Play();
        now++;
        if (GameController.have <= 0) leave(true);
        else
        if (now < need)
        {
            ND.GetDialogue(chapter, 0, 1, type, ref ask, ref yes, ref no);
            //Display=(int)Random.Range(0, (Ask1.Length));
            //获取新的真诚
            SB.Show(ask);
            //展示字幕
        }
        else
        {
            if (now > need) leave(true);
            else
            {
                float p = Random.value;
                if (p < P)
                {
                    ND.GetDialogue(chapter, 0, 0, type, ref ask, ref yes, ref no);
                    //Display = (int)Random.Range(0, (Ask2.Length));
                    //获取新的非真诚
                    SB.Show(ask);
                    //展示字幕
                }
                else leave(true);
            }

        }
    }
    public override void RightFunction()
    {
        ringAU.Play();
        leave(false);
    }

    void leave(bool flag)
    {
        if (flag)
        {
            SB.Show(yes);
        }
        else
        {
            SB.Show(no);
        }
        StartCoroutine(End());
    }
    //IEnumerator change()
    //{
    //    yield return new WaitForSeconds(1.25f);
    //    Left.GetComponent<SpriteRenderer>().sprite = unhold;
    //    Left.transform.DORotate(new Vector3(0, 0, 0), 1f);
    //    Left.transform.DOMoveX(-730, 1f);
    //    yield return new WaitForSeconds(1);
    //    ani = false;
    //}

    /*void Update()
    {
        if (ani || SB.doing)
        {
            Mytime = 1000 ;
            return;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Left.transform.DORotate(new Vector3(0, 0, 35), 0.8f);
            Left.transform.DOMoveX(-930, 0.8f);
            //胳膊 move rotate
            //Left.transform.DOMoveX(-450, 1);
            Mytime = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (Time.time - Mytime > 0.75)
            {
                Mytime = 100000;
                ani = true;
                Left.GetComponent<SpriteRenderer>().sprite = hold;
                Left.transform.DOMoveX(-530, 1.25f);
                Right.transform.DORotate(new Vector3(0, 0, 0), 0.8f);
                Right.transform.DOMoveX(681, 0.8f);
                StartCoroutine(change());
                GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController1>().have--;
                supplyAU.Play();
                //胳膊继续移动，给他一包粮食.
                //改变粮食图片

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
            if (Time.time - Mytime > 0.7f)
            {
                Mytime = 100000;
                ani = true;
                ringAU.Play();
                //按铃并回去
                Left.transform.DORotate(new Vector3(0, 0, 0), 0.85f);
                Left.transform.DOMoveX(-730, 0.85f);
                Right.transform.DORotate(new Vector3(0, 0, 0), 0.8f);
                Right.transform.DOMoveX(681, 0.8f);
                leave(false);
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
