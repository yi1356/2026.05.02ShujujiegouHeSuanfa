using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkedListCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LickedList01<int> a = new LickedList01<int>();
        a.Add(1);
        a.Add(2);
        a.Remove(1);
        a.Remove(1);
        a.Add(3);
        a.Add(4);
        a.Remove(3);
        LickedListNode01<int> node = a.firstNode;
        while (node!=null)
        {
            print(node.value);
            node = node.nextNode;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
//节点管理类
public class LickedList01<T> 
{//属性：头尾指针
    public LickedListNode01<T> firstNode;
    public LickedListNode01<T> lastNode;
    //方法：添加/移除
    public void Add(T value)
    {
        LickedListNode01 < T >node= new LickedListNode01<T>(value);
        if (firstNode==null)
        { firstNode = node;
          lastNode = firstNode;
        }
        else
        {
           lastNode.nextNode = node;
            node.beforNode = lastNode;
            lastNode = node;//注意这一步
        }
    }

    public void Remove(T value)
    {
        if (firstNode==null)
        {
            return;
        }
        if (firstNode.value.Equals(value))
        {
            firstNode.nextNode.beforNode = firstNode.beforNode;
            firstNode = firstNode.nextNode;
            if (firstNode==null)
            {
                lastNode = null;
            }
        }
        LickedListNode01<T> node = firstNode;
        while (node.nextNode!=null)//遍历除头节点以外的其他节点
        {
            if (node.nextNode.value.Equals(value))
            {//删除目标节点node.nextNode
                node.nextNode.nextNode.beforNode = node;
                node.nextNode = node.nextNode.nextNode;
                break;
            }
            node=node.nextNode;
        }
    }
}
//链表子节点
public class LickedListNode01<T>
{
    //每个子节点包括：一个数据域，两个指针域；
    public T value;
    public LickedListNode01(T value)
    {
         this.value= value;
    }
    public LickedListNode01<T> beforNode;
    public LickedListNode01<T> nextNode;
}

