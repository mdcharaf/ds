﻿using System;
using System.Collections.Generic;

namespace DS.DataStructures
{
    public class PriorityQueue<T>
    {
        class Node
        {
            public int Priority { get; set; }
            public T Object { get; set; }
        }

        //object array
        private readonly List<Node> _queue = new List<Node>();
        private int _heapSize = -1;
        private bool _isMinPriorityQueue;
        public int Count => _queue.Count;

        /// <summary>
        /// If min queue or max queue
        /// </summary>
        /// <param name="isMinPriorityQueue"></param>
        public PriorityQueue(bool isMinPriorityQueue = true)
        {
            _isMinPriorityQueue = isMinPriorityQueue;
        }

        /// <summary>
        /// Enqueue the object with priority
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="obj"></param>
        public void Enqueue(int priority, T obj)
        {
            Node node = new Node() { Priority = priority, Object = obj };
            _queue.Add(node);
            _heapSize++;
            //Maintaining heap
            if (_isMinPriorityQueue)
                BuildHeapMin(_heapSize);
            else
                BuildHeapMax(_heapSize);
        }
        /// <summary>
        /// Dequeue the object
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (_heapSize > -1)
            {
                var returnVal = _queue[0].Object;
                _queue[0] = _queue[_heapSize];
                _queue.RemoveAt(_heapSize);
                _heapSize--;
                //Maintaining lowest or highest at root based on min or max queue
                if (_isMinPriorityQueue)
                    MinHeapify(0);
                else
                    MaxHeapify(0);
                return returnVal;
            }
            else
                throw new Exception("Queue is empty");
        }
        /// <summary>
        /// Updating the priority of specific object
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="priority"></param>
        public void UpdatePriority(T obj, int priority)
        {
            int i = 0;
            for (; i <= _heapSize; i++)
            {
                Node node = _queue[i];
                if (object.ReferenceEquals(node.Object, obj))
                {
                    node.Priority = priority;
                    if (_isMinPriorityQueue)
                    {
                        BuildHeapMin(i);
                        MinHeapify(i);
                    }
                    else
                    {
                        BuildHeapMax(i);
                        MaxHeapify(i);
                    }
                }
            }
        }
        /// <summary>
        /// Searching an object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Has(T obj)
        {
            foreach (Node node in _queue)
                if (ReferenceEquals(node.Object, obj))
                    return true;
            return false;
        }

        /// <summary>
        /// Maintain max heap
        /// </summary>
        /// <param name="i"></param>
        private void BuildHeapMax(int i)
        {
            while (i >= 0 && _queue[(i - 1) / 2].Priority < _queue[i].Priority)
            {
                Swap(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }
        /// <summary>
        /// Maintain min heap
        /// </summary>
        /// <param name="i"></param>
        private void BuildHeapMin(int i)
        {
            while (i >= 0 && _queue[(i - 1) / 2].Priority > _queue[i].Priority)
            {
                Swap(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        private void MaxHeapify(int i)
        {
            int left = ChildL(i);
            int right = ChildR(i);

            int heighst = i;

            if (left <= _heapSize && _queue[heighst].Priority < _queue[left].Priority)
                heighst = left;
            if (right <= _heapSize && _queue[heighst].Priority < _queue[right].Priority)
                heighst = right;

            if (heighst != i)
            {
                Swap(heighst, i);
                MaxHeapify(heighst);
            }
        }
        private void MinHeapify(int i)
        {
            int left = ChildL(i);
            int right = ChildR(i);

            int lowest = i;

            if (left <= _heapSize && _queue[lowest].Priority > _queue[left].Priority)
                lowest = left;
            if (right <= _heapSize && _queue[lowest].Priority > _queue[right].Priority)
                lowest = right;

            if (lowest != i)
            {
                Swap(lowest, i);
                MinHeapify(lowest);
            }
        }
        private void Swap(int i, int j)
        {
            var temp = _queue[i];
            _queue[i] = _queue[j];
            _queue[j] = temp;
        }
        private int ChildL(int i)
        {
            return i * 2 + 1;
        }
        private int ChildR(int i)
        {
            return i * 2 + 2;
        }
    }
}