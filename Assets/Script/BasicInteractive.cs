using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class BasicInteractive : MonoBehaviour {

    public Sprite hold;
    public Sprite unhold;

    protected enum Ani_State
    {
        Leftani, Rightani, Frozen, Wait,End
    };
    protected Ani_State m_State;
    float pressTime = 100000;
    protected GameObject Left, Right;
    protected MainController1 GameController;
    protected AudioSource newsAU, ringAU, footstepsAU, supplyAU;
    protected Subtitles SB;

    public abstract void LeftFunction();
    public abstract void RightFunction();
    public abstract IEnumerator Begin();

    public void Start ()
    {
        m_State = Ani_State.Frozen;
        Left = GameObject.FindGameObjectWithTag("left");
        Right = GameObject.FindGameObjectWithTag("right");
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainController1>();
        newsAU = GameObject.FindGameObjectWithTag("news").GetComponent<AudioSource>();
        footstepsAU = GameObject.FindGameObjectWithTag("footstep").GetComponent<AudioSource>();
        supplyAU = GameObject.FindGameObjectWithTag("supply").GetComponent<AudioSource>();
        ringAU = GameObject.FindGameObjectWithTag("ring").GetComponent<AudioSource>();
        SB = GameObject.FindGameObjectWithTag("SB").GetComponent<Subtitles>();
        StartCoroutine(Begin());
    }
    public IEnumerator End()
    {
        Debug.Log("Frozen!");
        m_State = Ani_State.End;
        yield return new WaitForSeconds(2.25f);
        SB.Close();
        GetComponent<SpriteRenderer>().DOFade(0, 1.8f);
        footstepsAU.Play();
        //离开的动画
        yield return new WaitForSeconds(3);
        StartCoroutine(GameController.GetComponent<MainController1>().Next());
        Destroy(gameObject);
        
    }
    IEnumerator LeftAni()
    {
        yield return new WaitForSeconds(1.25f);
        Left.GetComponent<SpriteRenderer>().sprite = unhold;
        Left.transform.DORotate(new Vector3(0, 0, 0), 1f);
        Left.transform.DOMoveX(-730, 1f);
        yield return new WaitForSeconds(1);
        if (m_State!=Ani_State.End) m_State = Ani_State.Wait;
    }
    IEnumerator RightAni()
    {
        yield return new WaitForSeconds(0.8f);
        if (m_State != Ani_State.End) m_State = Ani_State.Wait;
    }

    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.A) && m_State== Ani_State.Wait)
        {
            m_State = Ani_State.Leftani;
            pressTime = Time.time;
            Left.transform.DORotate(new Vector3(0, 0, 35), 0.9f);
            Left.transform.DOMoveX(-930, 0.9f);
        }
        //上面是按下A

        if (Input.GetKeyUp(KeyCode.A) && m_State== Ani_State.Leftani)
        {
            if (Time.time>pressTime+0.7)
            {
                m_State = Ani_State.Frozen;
                //supplyAU.Play();
                Left.GetComponent<SpriteRenderer>().sprite = hold;
                Left.transform.DOMoveX(-530, 1.25f);
                StartCoroutine(LeftAni());
                LeftFunction();
            }
            else
            {
                m_State = Ani_State.Wait;
                Left.transform.DORotate(new Vector3(0, 0, 0), 0.85f);
                Left.transform.DOMoveX(-730, 0.85f);
            }
            pressTime = 100000;
        }
        //上面是松开A



        if (Input.GetKeyDown(KeyCode.D) && m_State == Ani_State.Wait)
        {
            m_State = Ani_State.Rightani;
            pressTime = Time.time;
            Right.transform.DORotate(new Vector3(0, 0, -35), 0.8f);
            Right.transform.DOMoveX(1100, 0.8f);
        }
        //上面是按下D

        if (Input.GetKeyUp(KeyCode.D) && m_State == Ani_State.Rightani)
        {
            if (Time.time > pressTime + 0.7)
            {
                pressTime = 100000;
                m_State = Ani_State.Frozen;
                Right.transform.DORotate(new Vector3(0, 0, 0), 0.8f);
                Right.transform.DOMoveX(681, 0.8f);
                StartCoroutine(RightAni());
                RightFunction();

            }
            else
            {
                m_State = Ani_State.Wait;
                pressTime = 100000;
                Right.transform.DORotate(new Vector3(0, 0, 0), 0.8f);
                Right.transform.DOMoveX(681, 0.8f);
                //胳膊移动回去
            }
        }
        //上面是松开D
    }
}
