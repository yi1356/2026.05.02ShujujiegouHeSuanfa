using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSort : MonoBehaviour
{
    // Start is called before the first frame update
    int[] arr = new int[] { 4,7,10,1,100,5,7,9,4,};
    void Start()
    {
        int[] tempArr = new int[arr.Length];
        merg_Sort(arr,0, arr.Length-1,tempArr);
        for (int i=0; i<arr.Length;i++)
        {
            Debug.Log(arr[i]);
        }
    }

    //（分）用来拆分
    //时间复杂度：O(nlogn)   空间复杂度：O(n)
   void merg_Sort(int[] arr,int Start,int end,int[] tempArr)
    {
        if (end <= Start) { return; }

        //拆：拆分为左右两个
        int mid = Start + (end - Start) / 2;
        merg_Sort(arr,Start,mid,tempArr);
        merg_Sort(arr,mid+1,end,tempArr);

        //有拆必有合，合并时排序
        merg_Arr(arr,Start,mid,end,tempArr);
    }

    //（治）用来合并排序
    //left:左数组起始    right:右数组起始    end:右数据终止  tempArr：临时数组
    private void merg_Arr(int[] arr, int left, int right, int end, int[] tempArr)
    {
        int start = left;           //记录开始位置
        int left_end = right - 1;    //得到左右支结束位置
        int p = 0;                  //临时结果数组指针

        while (left<=left_end && right<=end)//对左右两个数组处理
        {
            if (arr[left] <= arr[right])
                tempArr[p++] = arr[left++];
            else
                tempArr[p++] = arr[right++];
        }

        //如果左支未取完， 则将左支数据全部移到结果最后
        while (left <= left_end)
        {
            tempArr[p++] = arr[left++];
        }
        //如果右支未取完，则无需处理，因为它本身就在结果最后
        //将排好的数据返回到结果数组中
        for (int i=0;i<p;i++)
        {
            arr[start++] = tempArr[i];
        }
    }
}
