using UnityEngine;
using System.Collections;

public class LastDay : MonoBehaviour {
    public int delta=0;
    public int[] Have;
    private int num = 0;
    //特殊变化变量.
    public void Append(int n)
    {
        Have[num++] = n;
    }
    void Start()
    {
        Have = new int[100];
        num = 0;
    }
    public bool Query(int n)
    {
        for (int i = 0; i < num; i++) if (Have[i] == n) return true;
        return false;
    }
}
