using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSample
{
    public static class GraphProgram
    {
        #region 最短路径问题
        #region Dijkstra,迪科斯彻算法
        public static int Dijkstra(int[,] paths, int fromP, int toP)
        {
            var pointNum = paths.GetLength(0);
            var fromToAllPath = new int[pointNum];
            Array.Fill(fromToAllPath, int.MaxValue);
            fromToAllPath[fromP] = 0;
            var visitedPoints = new HashSet<int>();
            Dijkstra_internal(paths, visitedPoints, fromP, pointNum, fromToAllPath);
            return fromToAllPath[toP];
        }

        public static void Dijkstra_internal(int[,] paths, HashSet<int> visited, int current, int num, int[] fromToAllPath)
        {
            // fromToAllPath[i] 为源点到i点的最短距离
            // fromToAllPath[i]=min(fromToAllPath[i],fromToAllPath[k]+paths[k,i])
            var nexts = new List<int>();
            for (int next = 0; next < num; next++)
            {
                if (paths[current, next] != int.MaxValue && !visited.Contains(next))
                {
                    // 如果当前和下一个是通的，且下一个未访问过（避免回路死循环）
                    nexts.Add(next);
                    visited.Add(next);
                    var curToNext = paths[current, next];
                    if (fromToAllPath[next] > fromToAllPath[current] + curToNext)
                    {
                        fromToAllPath[next] = fromToAllPath[current] + curToNext;
                    }
                }
            }
            for (int i = 0; i < nexts.Count; i++)
            {
                Dijkstra_internal(paths, visited, nexts[i], num, fromToAllPath);
            }
        }
        #endregion

        #region 
        /// <summary>
        /// 我的dijkstra算法，用queue和hash
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="fromP"></param>
        /// <param name="toP"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int DijkstraQueue(int[,] paths, int fromP, int toP, int n)
        {
            // D(j)表示到j的最短路径
            // D(j)=D(k)+p(k,j)，k为和j和直接相连的点
            // 设D[i]为fromP到i点的最短距离
            var queue = new Queue<int>();// need to visit
            var visited = new HashSet<int>();
            queue.Enqueue(fromP);
            var d = InitFromPToAll(paths, fromP, n);
            while (queue.Count > 0)
            {
                var thisNode = queue.Dequeue();
                var toNodes = PushNeedVisitToQueue(visited, thisNode, queue, n, paths);
                for (var i = 0; i < toNodes.Count; i++)
                {
                    d[toNodes[i]] = Math.Min(d[toNodes[i]], paths[thisNode, toNodes[i]] == int.MaxValue ? int.MaxValue : d[thisNode] + paths[thisNode, toNodes[i]]);
                }
            }
            return d[toP];
        }
        private static int[] InitFromPToAll(int[,] paths, int fromP, int n)
        {
            int[] d = new int[n];
            for (var i = 0; i < n; i++)
            {
                d[i] = paths[fromP, i];
            }
            return d;
        }
        private static List<int> PushNeedVisitToQueue(HashSet<int> visited, int source, Queue<int> queue, int n, int[,] paths)
        {
            var res = new List<int>();
            for (var i = 0; i < n; i++)
            {
                if (paths[source, i] != int.MaxValue)
                {
                    if (!visited.Contains(i))
                    {
                        visited.Add(i);
                        queue.Enqueue(i);
                    }
                    res.Add(i);
                }
            }
            return res;
        }
        #endregion
        #region Floyd
        public static void Floyd(int[,] paths, int n)
        {
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if ((paths[i, k] != int.MaxValue && paths[k, j] != int.MaxValue)
                            && paths[i, j] > paths[i, k] + paths[k, j]
                            )
                        {
                            paths[i, j] = paths[i, k] + paths[k, j];
                        }
                    }
                }
            }
        }
        #endregion
        #endregion
    }
}
