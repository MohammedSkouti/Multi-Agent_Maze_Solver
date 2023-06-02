using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.Remoting.Channels;

using System.Linq;

namespace Reactive
{
    public class Utils
    {
        public static int NoExplorers = 1;

        private static Random rnd = new Random();
        public static Brush PickBrush()
        {
            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();
            int random = rnd.Next(20, 35);
            Brush result = (Brush)properties[random].GetValue(null, null);

            return result;
        }

        public static int Delay = 20;
        public static Random RandNoGen = new Random();

        /* public static int[,] maze =
           {   {1,1,1,0,1,1,1,1,1,1,1,1,1},
               {1,0,1,0,1,0,1,0,0,0,0,0,1},
               {1,0,1,0,0,0,1,0,1,1,1,0,1},
               {1,0,0,0,1,1,1,0,0,0,0,0,1},
               {1,0,1,0,0,0,0,0,1,1,1,0,1},
               {1,0,1,0,1,1,1,0,1,0,0,0,1},
               {1,0,1,0,1,0,0,0,1,1,1,0,1},
               {1,0,1,0,1,1,1,0,1,0,1,0,1},
               {1,0,0,0,0,0,0,0,0,0,1,0,1},
               {1,1,1,1,1,1,1,1,1,0,1,1,1}
             };*/
       /* public static int[,] maze =
        {
            { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},

            { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1},

            { 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1},

            { 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1},

            { 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1},

            { 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1},

            { 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1},

            { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1},

            { 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1},

            { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1},

            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1} };*/

        public static int[,] maze = {{ 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },

                    {1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1},

                    {1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 1},

                    { 1, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1},

                    { 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 1},

                    { 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1},

                    { 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},

                    { 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1},

                    { 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1},

                    { 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 1},

                    { 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1},

                    { 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1},

                    { 1, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1},

                    { 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1},

                    { 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1},

                    { 1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1},

                    { 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1},

                    { 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1},

                    { 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1},

                    { 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1},

                    { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1},

                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1},

                    { 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1},

                    { 1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1},

                    { 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 1},

                    { 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1},

                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
                    };

        /* public static string start = "0 3";
         public static string end = "9 9";*/

        /*   public static string start = "0 1";
           public static string end = "10 25";*/

        public static string start = "0 1";
        public static string end = "26 25";



        public static void ParseMessage(string content, out string action, out List<string> parameters)
        {
            string[] t = content.Split();

            action = t[0];

            parameters = new List<string>();
            for (int i = 1; i < t.Length; i++)
                parameters.Add(t[i]);
        }

        public static void ParseMessage(string content, out string action, out string parameters)
        {
            string[] t = content.Split();

            action = t[0];

            parameters = "";

            if (t.Length > 1)
            {
                for (int i = 1; i < t.Length - 1; i++)
                    parameters += t[i] + " ";
                parameters += t[t.Length - 1];
            }
        }

        public static string Str(object p1, object p2)
        {
            return string.Format("{0} {1}", p1, p2);
        }

        public static string Str(object p1, object p2, object p3)
        {
            return string.Format("{0} {1} {2}", p1, p2, p3);
        }

        // function to form edge between
        // two vertices source and dest
        public static void addEdge(Dictionary<string, List<string>> adj,
                                    string i, string j)
        {
            adj[i].Add(j);
            adj[j].Add(i);
        }

        // function to print the shortest
        // distance and path between source
        // vertex and destination vertex
        public static void shortestDistance(Dictionary<string, List<string>> adj,
                                                string s, string dest, int v, out List<string> path)
        {
            // predecessor[i] array stores
            // predecessor of i and distance
            // array stores distance of i
            // from s

            path = new List<string>();

            Dictionary<string, string> pred = new Dictionary<string, string>(v);
            Dictionary<string, int> dist = new Dictionary<string, int>(v);
            if (BFS(adj, s, dest,
                    v, pred, dist) == false)
            {
                Console.WriteLine("Given source and destination" +
                                " are not connected");
                return;
            }

            string crawl = dest;
            path.Add(crawl);

            while (pred[crawl] != null)
            {
                path.Add(pred[crawl]);
                crawl = pred[crawl];
            }

            // Print distance
            Console.WriteLine("Shortest path length is: " +
                                dist[dest]);

            // Print path
            Console.WriteLine("Path is ::");

            for (int i = path.Count - 1;
                    i >= 0; i--)
            {
                Console.Write(path[i] + ", ");
            }
        }

        // a modified version of BFS that
        // stores predecessor of each vertex
        // in array pred and its distance
        // from source in array dist
        private static bool BFS(Dictionary<string, List<string>> adj,
                                string src, string dest,
                                int v, Dictionary<string, string> pred,
                                Dictionary<string, int> dist)
        {
            // a queue to maintain queue of
            // vertices whose adjacency list
            // is to be scanned as per normal
            // BFS algorithm using List of int type
            List<string> queue = new List<string>();

            // bool array visited[] which
            // stores the information whether
            // ith vertex is reached at least
            // once in the Breadth first search
            Dictionary<string, bool> visited = new Dictionary<string, bool>(v);

            // initially all vertices are
            // unvisited so v[i] for all i
            // is false and as no path is
            // yet constructed dist[i] for
            // all i set to infinity
            /* for (int i = 0; i < v; i++)
             {
                 visited[i] = false;
                 dist[i] = int.MaxValue;
                 pred[i] = -1;
             }*/
            foreach (string cell in adj.Keys)
            {
                visited[cell] = false;
                dist[cell] = int.MaxValue;
                pred[cell] = null;
            }

            // now source is first to be
            // visited and distance from
            // source to itself should be 0
            visited[src] = true;
            dist[src] = 0;
            queue.Add(src);

            // bfs Algorithm
            while (queue.Count != 0)
            {
                string u = queue[0];
                queue.RemoveAt(0);

                for (int i = 0;
                        i < adj[u].Count; i++)
                {
                    if (visited[adj[u][i]] == false)
                    {
                        visited[adj[u][i]] = true;
                        dist[adj[u][i]] = dist[u] + 1;
                        pred[adj[u][i]] = u;
                        queue.Add(adj[u][i]);

                        // stopping condition (when we
                        // find our destination)
                        if (adj[u][i] == dest)
                            return true;
                    }
                }
            }
            return false;
        }

    }
}

