using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMP : MonoBehaviour
{
   
}
class Solution2
{
    //前缀表（不减一）
    public int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle))
        {
            return 0;
        }
        if (needle.Length > haystack.Length || string.IsNullOrEmpty(haystack))
        {
            return -1;
        }
        return KMP(haystack, needle);
    }
    //得到模式字符串的前缀表后，与传入的字符串比较
    private int KMP(string haystack, string needle)
    {
        int[] next = new int[needle.Length];
        getNext(next, needle);
        int j = 0;
        for (int i = 0; i < haystack.Length; i++)
        {
            while (j > 0 && needle[j] != haystack[i])//字符不匹配      且匹配字符串不在最开始时(直到匹配 或 移动到了头部)
            {
                j = next[j - 1];
            }
            if (needle[j] == haystack[i])//字符匹配     模式字符串索引后移
            {
                j++;
            }
            if (j == needle.Length)//找到目标      当模式字符串索引移动到最后时（找到匹配字符串时），返回目标
            {
                return i - j + 1;
            }
        }
        return -1;

    }
    //获取前缀表的方法（记住）***？？？
    private void getNext(int[] next, string s)
    {

        //第一步:初始化
        //第二步:处理相同时的情况
        //第三步:处理不同时的情况

        //第一步:初始化
        int i = 0;
        int j = 1;
        next[0] = 0;

        while (j < next.Length)
        {
            if (s[j] == s[i]) //第二步:处理相同时的情况
            {
                i++;
                next[j] = i;
                j++;
            }
            else//第三步:处理不同时的情况
            {
                if (i == 0)
                {
                    next[j] = 0;
                    j++;
                }
                else
                {
                    i = next[i - 1];//
                }

            }
        }

    }
}
