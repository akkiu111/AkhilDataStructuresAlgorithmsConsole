using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologicalSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = TopologicalSort(new List<int> { 1, 2, 3, 4 }, new List<int[]> {
                new int[]{ 1, 2 },
                new int[]{ 1, 3 },
                new int[]{ 3, 2 },
                new int[]{ 4, 2 },
                new int[]{ 4, 3 }
            });

            Console.ReadLine();

        }

        public static List<int> TopologicalSort(List<int> jobs, List<int[]> deps)
        {
            // Write your code here.
            JobGraph jobGraph = CreateJobGraph(jobs, deps);
            return getOrderedGraphs(jobGraph);
        }

        public static JobGraph CreateJobGraph(List<int> jobs, List<int[]> deps)
        {
            JobGraph jobGraph = new JobGraph(jobs);
            foreach (int[] dep in deps)
            {
                jobGraph.addPrereq(dep[1], dep[0]);
            }

            return jobGraph;
        }

        public static List<int> getOrderedGraphs(JobGraph jobGraph)
        {
            List<int> topologicalSort = new List<int>();
            foreach (JobNode node in jobGraph.nodes)
            {
                bool containsCycle = getTopologicalSort(node, topologicalSort);
                if(containsCycle)
                {
                    return new List<int>();
                }
            }

            return topologicalSort;
        }

        public static bool getTopologicalSort(JobNode node, List<int> topologicalSort)
        {

            if (node.isVisiting)
            {
                return true;
            }
            if (node.isVisited)
            {
                return false;
            }

            node.isVisiting = true;
            foreach (JobNode prereq in node.prereqs)
            {
                bool containsCycle = getTopologicalSort(prereq, topologicalSort);
                if(containsCycle)
                {
                    return true;
                }
            }
            node.isVisited = true;
            node.isVisiting = false;
            topologicalSort.Add(node.job);
            return false;
        }

        public class JobGraph
        {
            public List<JobNode> nodes;
            public Dictionary<int, JobNode> graph;

            public JobGraph(List<int> jobs)
            {
                nodes = new List<JobNode>();
                graph = new Dictionary<int, JobNode>();
                foreach (int job in jobs)
                {
                    addNode(job);
                }
            }

            public void addNode(int job)
            {
                graph.Add(job, new JobNode(job));
                nodes.Add(graph[job]);
            }

            public void addPrereq(int job, int prereq)
            {
                JobNode jobNode = getNode(job);
                JobNode prereqNode = getNode(prereq);
                jobNode.prereqs.Add(prereqNode);
            }

            public JobNode getNode(int job)
            {
                if (!graph.ContainsKey(job))
                {
                    addNode(job);
                }
                return graph[job];
            }

        }

        public class JobNode
        {
            public int job;
            public List<JobNode> prereqs;
            public bool isVisited;
            public bool isVisiting;

            public JobNode(int job)
            {
                this.job = job;
                prereqs = new List<JobNode>();
                isVisited = false;
                isVisiting = false;
            }
        }
    }

}
