using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDate : MonoBehaviour
{
    string s = "你好世界";
    // Start is called before the first frame update
    void Start()
    {

        ////1、本质：object 数组；先进后出

        ////2、申明
        //Stack a = new Stack();

        ////3、增取查改
        //a.Push(s); a.Push(1);

        //print("数据结构 栈取出的数值"+a.Pop());

        //print("数据结构 栈只能查栈顶的内容" + a.Peek()+ "栈查是否包含内容");
        int[] c = new int[] { };
        c = TwoSum2(new int[] { 2, 7, 11, 15 },9);
        for (int i=0;i<c.Length;i++)
        {
            Debug.Log(c[i]);
        }


    }
    public int[] TwoSum(int[] nums, int target)
    {
        int[] a=new int[2];
        int index = -1;
        for (int i = 0; i <nums.Length;i++)
        {
            for (int j=i+1;j< nums.Length;j++)
            {
                if (nums[i] + nums[j]== target)
                {
                    index++;
                    a[index] = i;
                    a[index + 1] = j;
                }
            }
           
        }
        return a;

    }
    public int[] TwoSum2(int[] nums, int target)
    {
        Dictionary<int, int> hashtable = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (hashtable.ContainsKey(target - nums[i]))
            {
                return new int[] { hashtable[target - nums[i]], i };
            }
            hashtable[nums[i]] = i;
        }
        return new int[0];
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
