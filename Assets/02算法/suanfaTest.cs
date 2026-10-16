using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class suanfaTest : MonoBehaviour
{
    int[] nums = new int[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 };
    IList<int> a = new List<int>();
    int [][]matrix = new int[3][] { new int[]{ 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 9, 10, 11, 12 } };
    int[][] matrix2 = new int[1][] { new int[] { 6, 9, 7 } };
    int[] nums1 = new int[] { 1, 2, 3, 0, 0,0  };

    string [] nums2 = new string[] { "4", "13", "5", "/", "+" };


    void Start()
    {
       // Solution a = new Solution();
        //    Debug.Log(a.Reversestring("sjoiwihoitu", 2));
        // a.Merge(nums1, 3, nums2, 3);
        //a.IsHappy(19);
        //print(a.EvalRPN(nums2));
       

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
    public void readList(IList<int> nums)
    {
        foreach (var item in nums)
        {
            print(item);
        }  
    }
    public void readLinkedList(ListNode head)
    {
        ListNode node = new ListNode(0);
        node.next = head;
        int dex = 0;
        while (node.next != null)
        {
            print(node.next.val);
            node = node.next;
           dex++;
        }
    }
   

}


public class Quik
{
    //求时间复杂度，空间复杂度
    //1、递归函数

    public void QuickSort(int [] arr,int start,int end)
    {
        if (start>=end) { return; }
        int pivotIndex = QuickSort_onece(arr, start, end);
        QuickSort(arr,start, pivotIndex-1);
        QuickSort(arr, pivotIndex +1,end);
    }
    //2、划分函数
    public int QuickSort_onece(int[] arr, int start, int end)
    {
        int i = start;
        int j = end;
        int pivot=arr[i];
        while (i<j)
        {
            while (i<j&&arr[j]>=pivot)
            {
                j--;
            }
            arr[i] = arr[j];
            while (i<j&&arr[i]<=pivot)
            {
                i++;
            }
            arr[j] = arr[i];
        }
        arr[i] = pivot;
        return pivot;
    }
}
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}


//时间复杂度O(m+n)、空间复杂度O(n)
public class TreeNode 
    {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left = null,TreeNode Right=null)
    {
        this.val = val;
        this.left = left;
        this.right = Right;
    }
}

public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}
public class Solution
{
    //思路：回溯算法处理组合问题
    //套用模板，两次剪枝

   //注意：优化前后的时间复杂度都是 O（n*2^n） 空间复杂度O(n)
   
    List<IList<int>> result = new List<IList<int>>();
    List<int> path = new List<int>();
    int sum = 0;
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        backtracking(k, 9, n, 1);
        return result;
    }
    //回溯算法三部曲：
    //回溯函数的参数和返回值
    void backtracking(int k, int n,int target,int startIndex)
    {
        if (sum>target) { return; }//剪枝
        //回溯函数结束条件
        if (path.Count==k)
        {
            if (sum==target)
            {
                List<int> newpath = new List<int>();
                newpath.AddRange(path);
                result.Add(newpath);
            }
            return;
        }
        //回溯函数遍历过程
        for (int i=startIndex;i<=n-(k-path.Count)+1;i++)//剪枝
        {
            path.Add(i);sum += i;
            backtracking( k, n,target,i+1);
            path.RemoveAt(path.Count-1);sum -= i;
        }
    }

}