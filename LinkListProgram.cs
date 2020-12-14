using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSample
{
    /// <summary>
    /// 链表
    /// </summary>
    public static  class LinkListProgram
    {
        #region lru
        #region 我的解法
        public class LRUCache
        {
            public string Key { get; set; }
            public object Val { get; set; }
            public LRUCache Before { get; set; }
            public LRUCache Next { get; set; }
            public static int _capacity = 3;
            public static Dictionary<string, LRUCache> _cache = new Dictionary<string, LRUCache>();
            public static LRUCache _head = new LRUCache("head", "head"), _tail = new LRUCache("tail", "tail");// 为方便访问头和尾
            static LRUCache()
            {
                _head.Next = _tail;
                _head.Before = null;
                _tail.Before = _head;
                _tail.Next = null;
            }
            public LRUCache(string key, object val)
            {
                this.Key = key;
                this.Val = val;
            }

            public object Get(string key)
            {
                _cache.TryGetValue(key, out LRUCache node);
                return node.Val;
            }

            public static void Put(string key, object val)
            {
                if (_cache.ContainsKey(key))
                {
                    // move the key to head
                    var node = (LRUCache)_cache[key];
                    RemoveNode(node);
                    MoveToHead(node);
                }
                else
                {
                    var cur = new LRUCache(key, val);
                    if (_cache.Count < _capacity)
                    {
                        // add node to head
                        MoveToHead(cur);
                    }
                    else
                    {
                        // remove the buttom
                        _cache.Remove(_tail.Before.Key);
                        RemoveNode(_tail.Before);
                        // add to the head
                        MoveToHead(new LRUCache(key, val));
                    }
                    _cache.Add(key, cur);
                }

            }



            private static void MoveToHead(LRUCache node)
            {
                var headNext = _head.Next;
                _head.Next = node;
                node.Next = headNext;
                node.Before = _head;
                headNext.Before = node;
            }
            private static void RemoveNode(LRUCache node)
            {
                if (node.Before != null)
                {
                    node.Before.Next = node.Next;
                }
                if (node.Next != null)
                {
                    node.Next.Before = node.Before;
                }
            }
        }
        #endregion
        //public class LRUCache
        //{
        //    class DLinkedNode
        //    {
        //        int key;
        //        int value;
        //        DLinkedNode prev;
        //        DLinkedNode next;
        //        public DLinkedNode() { }
        //        public DLinkedNode(int _key, int _value) { key = _key; value = _value; }
        //    }

        //    private Map<Integer, DLinkedNode> cache = new HashMap<Integer, DLinkedNode>();
        //    private int size;
        //    private int capacity;
        //    private DLinkedNode head, tail;

        //    public LRUCache(int capacity)
        //    {
        //        this.size = 0;
        //        this.capacity = capacity;
        //        // 使用伪头部和伪尾部节点
        //        head = new DLinkedNode();
        //        tail = new DLinkedNode();
        //        head.next = tail;
        //        tail.prev = head;
        //    }

        //    public int get(int key)
        //    {
        //        DLinkedNode node = cache.get(key);
        //        if (node == null)
        //        {
        //            return -1;
        //        }
        //        // 如果 key 存在，先通过哈希表定位，再移到头部
        //        moveToHead(node);
        //        return node.value;
        //    }

        //    public void put(int key, int value)
        //    {
        //        DLinkedNode node = cache.get(key);
        //        if (node == null)
        //        {
        //            // 如果 key 不存在，创建一个新的节点
        //            DLinkedNode newNode = new DLinkedNode(key, value);
        //            // 添加进哈希表
        //            cache.put(key, newNode);
        //            // 添加至双向链表的头部
        //            addToHead(newNode);
        //            ++size;
        //            if (size > capacity)
        //            {
        //                // 如果超出容量，删除双向链表的尾部节点
        //                DLinkedNode tail = removeTail();
        //                // 删除哈希表中对应的项
        //                cache.remove(tail.key);
        //                --size;
        //            }
        //        }
        //        else
        //        {
        //            // 如果 key 存在，先通过哈希表定位，再修改 value，并移到头部
        //            node.value = value;
        //            moveToHead(node);
        //        }
        //    }

        //    private void addToHead(DLinkedNode node)
        //    {
        //        node.prev = head;
        //        node.next = head.next;
        //        head.next.prev = node;
        //        head.next = node;
        //    }

        //    private void removeNode(DLinkedNode node)
        //    {
        //        node.prev.next = node.next;
        //        node.next.prev = node.prev;
        //    }

        //    private void moveToHead(DLinkedNode node)
        //    {
        //        removeNode(node);
        //        addToHead(node);
        //    }

        //    private DLinkedNode removeTail()
        //    {
        //        DLinkedNode res = tail.prev;
        //        removeNode(res);
        //        return res;
        //    }
        //}

        #endregion

        /// <summary>
        /// 合并两个有序链表
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public static ListNode Method_21_1(ListNode node1,ListNode node2)
        {
            // 1->3->5
            // 2->4->6
            if (node1 == null)
            {
                return node2;
            }
            if (node2 == null)
            {
                return node1;
            }
            if (node1.Val < node2.Val)
            {
                node1.Next = Method_21_1(node1.Next, node2);
                return node1;
            }
            else
            {
                node2.Next = Method_21_1(node2.Next, node1);
                return node2;
            }
        }


        #region 反转链表
        public static ListNode Method_206_Recursion(ListNode node1)
        {
            // 1->2->3->4
            //边界
            if (node1.Next == null)
            {
                return node1;
            }
            //逻辑
            var nextNewNode = Method_206_Recursion(node1.Next);
            node1.Next.Next = node1;
            node1.Next = null;
            return nextNewNode;
        }
        public static ListNode Method_206_Iteration(ListNode listNode)
        {
            // new
            // 1->2->3
            // cur
            ListNode newNode = null, cur = null;
            while (listNode != null)
            {
                cur = listNode;
                listNode = listNode.Next;
                cur.Next = newNode;
                newNode = cur;
            }
            return newNode;
        }
        #endregion

    }
}
