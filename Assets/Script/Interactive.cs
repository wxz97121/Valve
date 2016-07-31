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
    public string[] Ask0;
    public string[] Ask1;
    public string[] Ask2;
    public string[] Ask0_Yes;
    public string[] Ask1_Yes;
    public string[] Ask2_Yes;
    public string[] Ask0_No;
    public string[] Ask1_No;
    public string[] Ask2_No;
    private int Display;
    private int No;
    private Subtitles SB;
    private GameObject Left, Right;
    private AudioSource newsAU;
    private AudioSource footstepsAU;
    private AudioSource supplyAU;
    private AudioSource ringAU;
    public Sprite hold;
    public Sprite unhold;
    public IEnumerator First()
    {
        newsAU = GameObject.FindGameObjectWithTag("news").GetComponent<AudioSource>();
        footstepsAU = GameObject.FindGameObjectWithTag("footstep").GetComponent<AudioSource>();
        supplyAU = GameObject.FindGameObjectWithTag("supply").GetComponent<AudioSource>();
        ringAU = GameObject.FindGameObjectWithTag("ring").GetComponent<AudioSource>();
        SB = GameObject.FindGameObjectWithTag("SB").GetComponent<Subtitles>();
        done = false;
        now = 0;
        Display = (int)Random.Range(0,(Ask0.Length));
        No = 0;
        Left = GameObject.FindGameObjectWithTag("left");
        Right = GameObject.FindGameObjectWithTag("right");
        yield return new WaitForSeconds(1);
        SB.Show(Ask0[Display]);
        //显示气泡，Ask0[Display]
    }

    void leave(bool flag)
    {
        if (flag)
        {
            done = true;
            if (No == 0) SB.Show(Ask0_Yes[Display]);
            if (No == 1) SB.Show(Ask1_Yes[Display]);
            if (No == 2) SB.Show(Ask2_Yes[Display]);
        }
        else
        {
            done = true;
            if (No == 0) SB.Show(Ask0_No[Display]);
            if (No == 1) SB.Show(Ask1_No[Display]);
            if (No == 2) SB.Show(Ask2_No[Display]);
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
            Left.transform.DORotate(new Vector3(0, 0,35), 0.8f);
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
                Left.transform.DOMoveX(-530,1.25f);
                StartCoroutine(change());
                
                supplyAU.Play();
                //胳膊继续移动，给他一包粮食.
                //改变粮食图片
                now++;
                if (now < need)
                {

                    Display=(int)Random.Range(0, (Ask1.Length));
                    No = 1;
                    SB.Show(Ask1[Display]);
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
                            Display = (int)Random.Range(0, (Ask2.Length));
                            No = 2;
                            SB.Show(Ask2[Display]);
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
            Right.transform.DORotate(new Vector3(0,0,-35), 0.8f);
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
