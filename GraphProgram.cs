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
            //int[i,j]=int[i,k]+int[k,j] //k in (和j连接的点)
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
