using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LikedListTest : MonoBehaviour
{
    #region 1、申明
    //链表对象需要掌握两个类linkedList、linkedListNode
    LinkedList<string> linkedlist01 = new LinkedList<string>();
    LinkedList<int> linkedlist02 = new LinkedList<int>();
    #endregion
    //LinkedList是一个可变类型的泛型双向列表
    void Start()
    {


        #region 2、增删查改
        //增
        linkedlist01.AddFirst("你好");
        linkedlist01.AddLast("世"); linkedlist01.AddLast("界");
        LinkedListNode<string> n = linkedlist01.Find("世"); linkedlist01.AddAfter(n,"1"); linkedlist01.AddBefore(n, "0");

        //删
        //linkedlist01.RemoveFirst();
        //linkedlist01.RemoveLast();
        //linkedlist01.Remove("1");
        //linkedlist01.Clear();

        //查
        LinkedListNode<string> m01 = linkedlist01.Find("1"); 
        //if (linkedlist01.Contains("你好")) { print("要查找的值存在"); }
        //改
        m01.Value = "10086";
        //print( m01.Value);
        #endregion

        #region 3、遍历
        //foreach (string item in linkedlist01)  {print(item);}

        //LinkedListNode<string> o01 = linkedlist01.First;
        //while (o01!=null)
        //{
        //    print(o01.Value);
        //    o01=o01.Next;
        //}

        LinkedListNode<string> o02 = linkedlist01.Last;
        while (o02 != null)
        {
            print(o02.Value);
            o02 = o02.Previous;
        }

        #endregion
    }
    #region 4、相比于顺序存储
    //增删查改角度
    //链式 增删 计算优势
    //顺序 查改 使用优势
    #endregion

}
