using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linckedreate2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public class Solution
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            //移除头节点情况
            if (head == null) { return null; }
            while (head.val == val && head.next != null)//避免空指针引用报错
            {
                head = head.next;
            }
            if (head.val == val && head.next == null)
            {
                head = null;
                return head;
            }
            //移除其他节点
            ListNode node = head;
            while (node.next != null)
            {
                if (node.next.val == val)
                {
                    node.next = node.next.next;
                }
                else
                {
                    node = node.next;
                }
            }
            return head;

        }


    }
    public class LinkedNode
    {
        public LinkedNode preNode;
        public LinkedNode nextNode;
        public int value;
        public LinkedNode(int value)
        {
            this.value = value;
        }

    }

    public class MyLinkedList
    {
        public LinkedNode headNode;
        public LinkedNode lastNode;
        public MyLinkedList()
        {


        }

        public int Get(int index)
        {
            int dex = 0;
            LinkedNode node = new LinkedNode(0);
            node.nextNode = headNode;
            if (index < 0)
            {
                return -1;
            }
            while (node.nextNode != null)
            {
                if (index == dex)
                {
                    return node.nextNode.value;
                }
                node = node.nextNode;
                dex++;

            }
            return -1;
        }



        public void AddAtTail(int val)
        {
            LinkedNode node = new LinkedNode(val);
            if (lastNode == null)
            {
                headNode = node;
                lastNode = node;
            }
            else
            {
                lastNode.nextNode = node;
                node.preNode = lastNode;
                lastNode = node;
            }
        }
        public LinkedNode GetNode(int index)
        {
            if (index < 0)
            {
                return null;
            }
            int dex = 0;
            LinkedNode node = new LinkedNode(0);
            if (headNode != null)
            { node.nextNode = headNode; }
            else { return null; }
            while (node.nextNode != null)
            {
                if (index == dex) { return node.nextNode; }
                node = node.nextNode;
                dex++;
            }
            return null;
        }
        public int GetLength()
        {
            int dex = 0;
            LinkedNode node = new LinkedNode(0);
            node.nextNode = headNode;
            while (node.nextNode != null)
            {
                node = node.nextNode;
                dex++;
            }
            return dex;
        }
        public void AddAtIndex(int index, int val)
        {
            if (index > GetLength()) { return; }
            LinkedNode node = new LinkedNode(val);
            if (GetLength() == index)
            {
                if (GetLength() == 0)
                {
                    headNode = node;
                    lastNode = node;
                    return;
                }
                lastNode.nextNode = node;
                node.preNode = lastNode;
                lastNode = node;
            }
            else
            {
                if (GetNode(index) != null)
                {
                    LinkedNode nowNode = GetNode(index);
                    if (nowNode == headNode)
                    {
                        headNode.preNode = nowNode;
                        nowNode.nextNode = headNode;
                        headNode = nowNode;
                    }
                    else
                    {
                        node.nextNode = nowNode;
                        node.preNode = nowNode.preNode;
                        nowNode.preNode.nextNode = node;
                        nowNode.preNode = node;
                    }

                }
            }
        }
        public void AddAtHead(int val)
        {
            AddAtIndex(0, 10);
            //LinkedNode node = new LinkedNode(val);
            //if (headNode == null)
            //{
            //    headNode = node;
            //    lastNode = node;
            //}
            //else
            //{
            //    headNode.preNode = node;
            //    node.nextNode = headNode;
            //    headNode = node;
            //}
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= GetLength())
            {
                return;
            }
            LinkedNode nowNode = GetNode(index);
            //Debug.Log(nowNode.value);
            if (nowNode != null)
            {
                if (nowNode.preNode != null && nowNode.nextNode != null)
                {
                    nowNode.nextNode.preNode = nowNode.preNode;
                    nowNode.preNode.nextNode = nowNode.nextNode;
                }
                else if (nowNode.preNode == null && nowNode.nextNode != null)
                {
                    //headNode = nowNode;
                    //nowNode.nextNode.preNode = nowNode.preNode;
                    //nowNode = nowNode.nextNode;
                    headNode.nextNode.preNode = headNode.preNode;
                    headNode = headNode.nextNode;

                }
                else if (nowNode.preNode != null && nowNode.nextNode == null)
                {
                    nowNode.preNode.nextNode = null;
                    nowNode = nowNode.preNode;
                }
                else
                {
                    nowNode = null;
                }
            }

        }
    }
}
