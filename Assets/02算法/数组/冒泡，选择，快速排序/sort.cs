using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sort : MonoBehaviour
{
    int[] nums = new int[] { 0, 9, 2, 3,10, 5, 6, 6 };
    // Start is called before the first frame update
    void Start()
    {
        //selectSort(nums);
        QuickSort(nums,0,7);
        //bubbleSort(nums);
        readSort(nums);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void readSort(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            print(nums[i]);
        }
    }
    //1、冒泡排序：两两相邻不停比较、不停交换、比较n轮、时间复杂度O(n^2)
    public void bubbleSort(int [] nums)
    {
        bool isSort = false;
        //①比较n轮
        for (int i=0;i< nums.Length;i++)
        {
            //②两两相邻相互比较
            isSort = false;
            int num;
            for (int j = 0; j < nums.Length-1-i; j++)
            {
                //③交换
                if (nums[j]> nums[j+1])
                {
                    isSort = true;
                    num = nums[j];
                    nums[j] = nums[j+1];
                    nums[j + 1] = num;
                }
            }
            if (!isSort)
            {
                break;
            }
        }
    }
    //2、选择排序:新建中间商、依次比较找出极值、放入目标位置、比较n轮、时间复杂度O(n^2)
    public void selectSort(int[] nums)
    {
        //①新建中间商
        int index =0;
        int num=0;
        //②比较n轮
        for (int i=0;i<nums.Length;i++)
        {
            //③依次比较找出极值
            index = i;
            for (int j=i+1;j< nums.Length;j++)
            {
                if (nums[index] > nums[j])
                {
                    index = j;
                }
            }

            if (index!=i)
            {
                //④放入目标位置
                num = nums[index];
                nums[index] = nums[i];
                nums[i] = num;
            }
        }
    }
    #region 3、快速排序:分治思想,选择基准、划分操作、递归的对两个序列进行快速排序。O(nlogn)***************************
    //递归代码
    public void QuickSort(int[] arr, int begin, int end)
    {
        if (begin >= end) return;//两个指针重合就返回，（也是递归的结束条件）
        int pivotIndex = QuickSort_Once(arr, begin,end);//会得到一个基准值下表

        QuickSort(arr,begin, pivotIndex-1);//对基准的左侧进行排序 递归
        QuickSort(arr, pivotIndex +1,end);//对基准的左侧进行排序 递归

    }
    //划分代码
    private static int QuickSort_Once(int [] arr,int begin,int end)
    {
        int pivot = arr[begin];//将首元素作为基准元素
        int i = begin;
        int j = end;
        while (i<j)
        {
            while (arr[j]>= pivot&& i < j)//从右到左，寻找第一个小于基准pivot的元素
            {
                j--;
            }
            arr[i] = arr[j];//这里很难理解（交换），可简单想为第一次交换后arr[j]这个格子内容为空*****************************

            while (arr[i]<=pivot&& i < j)
            { 
                i++;
            }
            arr[j] = arr[i];
        }
        //至此必定是i=j的情况;锁定为的必然为基准位置（赋值）
        arr[i] = pivot;
        return i;
    }
    #endregion

}
