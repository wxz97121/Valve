using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Interactive : MonoBehaviour
{
    public bool done;
    public int need;
    public float P;
    public int type;
    public int now;
    private float Mytime;
    /*    public string[] Ask0;
        public string[] Ask1;
        public string[] Ask2;
        public string[] Ask0_Yes;
        public string[] Ask1_Yes;
        public string[] Ask2_Yes;
        public string[] Ask0_No;
        public string[] Ask1_No;
        public string[] Ask2_No; */
    string ask;
    string yes;
    string no;
    private Subtitles SB;
    private GameObject Left, Right;
    private AudioSource newsAU;
    private AudioSource footstepsAU;
    private AudioSource supplyAU;
    private AudioSource ringAU;
    public Sprite hold;
    public Sprite unhold;
    private int chapter;
    private NewDialogue ND;
    public IEnumerator First()
    {
        chapter = transform.parent.gameObject.name[7] - 48;
        newsAU = GameObject.FindGameObjectWithTag("news").GetComponent<AudioSource>();
        footstepsAU = GameObject.FindGameObjectWithTag("footstep").GetComponent<AudioSource>();
        supplyAU = GameObject.FindGameObjectWithTag("supply").GetComponent<AudioSource>();
        ringAU = GameObject.FindGameObjectWithTag("ring").GetComponent<AudioSource>();
        SB = GameObject.FindGameObjectWithTag("SB").GetComponent<Subtitles>();
        ND = GameObject.FindGameObjectWithTag("ND").GetComponent<NewDialogue>();
        done = false;
        now = 0;
        //Display = (int)Random.Range(0,(Ask0.Length));
        //去找newDialogue获取一组
        ND.GetDialogue(chapter, 1, 1, type, ref ask, ref yes, ref no);
        Left = GameObject.FindGameObjectWithTag("left");
        Right = GameObject.FindGameObjectWithTag("right");
        yield return new WaitForSeconds(1);
        SB.Show(ask);
        //显示气泡，A
    }

    void leave(bool flag)
    {
        done = true;
        if (flag)
        {
            SB.Show(yes);
        }
        else
        {
            SB.Show(no);
        }
    }
    IEnumerator change()
    {
        yield return new WaitForSeconds(1.25f);
        Left.GetComponent<SpriteRenderer>().sprite = unhold;
        Left.transform.DORotate(new Vector3(0, 0, 0), 1f);
        Left.transform.DOMoveX(-730, 1f);
    }
    void Update()
    {

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
                Left.GetComponent<SpriteRenderer>().sprite = hold;
                Left.transform.DOMoveX(-530, 1.25f);
                StartCoroutine(change());

                supplyAU.Play();
                //胳膊继续移动，给他一包粮食.
                //改变粮食图片
                now++;
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
                ringAU.Play();
                //按铃并回去
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

    }
}
