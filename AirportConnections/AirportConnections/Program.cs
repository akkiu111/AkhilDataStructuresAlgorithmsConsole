using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportConnections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> AIRPORTS = new List<string>(){
        "BGI",
        "CDG",
        "DEL",
        "DOH",
        "DSM",
        "EWR",
        "EYW",
        "HND",
        "ICN",
        "JFK",
        "LGA",
        "LHR",
        "ORD",
        "SAN",
        "SFO",
        "SIN",
        "TLV",
        "BUD"
    };

            string STARTING_AIRPORT = "LGA";

            List<List<string>> routes = new List<List<string>>();
            routes.Add(new List<string>(){
            "DSM", "ORD"
        });
            routes.Add(new List<string>(){
            "ORD", "BGI"
        });
            routes.Add(new List<string>(){
            "BGI", "LGA"
        });
            routes.Add(new List<string>(){
            "SIN", "CDG"
        });
            routes.Add(new List<string>(){
            "CDG", "SIN"
        });
            routes.Add(new List<string>(){
            "CDG", "BUD"
        });
            routes.Add(new List<string>(){
            "DEL", "DOH"
        });
            routes.Add(new List<string>(){
            "DEL", "CDG"
        });
            routes.Add(new List<string>(){
            "TLV", "DEL"
        });
            routes.Add(new List<string>(){
            "EWR", "HND"
        });
            routes.Add(new List<string>(){
            "HND", "ICN"
        });
            routes.Add(new List<string>(){
            "HND", "JFK"
        });
            routes.Add(new List<string>(){
            "ICN", "JFK"
        });
            routes.Add(new List<string>(){
            "JFK", "LGA"
        });
            routes.Add(new List<string>(){
            "EYW", "LHR"
        });
            routes.Add(new List<string>(){
            "LHR", "SFO"
        });
            routes.Add(new List<string>(){
            "SFO", "SAN"
        });
            routes.Add(new List<string>(){
            "SFO", "DSM"
        });
            routes.Add(new List<string>(){
            "SAN", "EYW"
        });

            var output = AirportConnections(AIRPORTS, routes, STARTING_AIRPORT) == 3;
            Console.ReadLine();
        }

        public static int AirportConnections(
        List<string> airports,
        List<List<string>> routes,
        string startingAirport
        )
        {
            // Write your code here.
            //T.C is O(A*(A+R) + ALOGA + A + R) and S.C is O(A+R)
            //where A is the no of airports and R is the number of routes
            Dictionary<string, AirportNode> airportGraph = createAirportGraph(airports, routes);
            List<AirportNode> unReachableAirportNodes = getUnReachableAirportNodes(
                airportGraph, airports, startingAirport);
            markUnreachableAirportNodes(airportGraph, unReachableAirportNodes);
            return getMinimumNumberOfNewConnections(airportGraph, unReachableAirportNodes);
        }

        //T.C and S.C is O(A+R) where A is the no of airports and R is the number of routes
        public static Dictionary<string, AirportNode> createAirportGraph(List<string> airports,
            List<List<string>> routes)
        {
            Dictionary<string, AirportNode> airportGraph = new Dictionary<string, AirportNode>();
            foreach (string airport in airports)
            {
                airportGraph[airport] = new AirportNode(airport);
            }
            foreach (List<string> route in routes)
            {
                string airport = route[0];
                string connection = route[1];
                airportGraph[airport].connections.Add(connection);
            }
            return airportGraph;
        }

        //T.C is O(ALogA + A + R) and S.C is O(1) where A is the no of airports
        //and R is the number of routes
        public static List<AirportNode> getUnReachableAirportNodes
            (Dictionary<string, AirportNode> airportGraph, List<string> airports,
            string startingAirport)
        {

            HashSet<string> visitedAirports = new HashSet<string>();
            depthFirstTraverseAirports(airportGraph, startingAirport, visitedAirports);
            List<AirportNode> unReachableAirportNodes = new List<AirportNode>();
            foreach (string airport in airports)
            {
                if (visitedAirports.Contains(airport))
                {
                    continue;
                }
                AirportNode airportNode = airportGraph[airport];
                airportNode.isReachable = false;
                unReachableAirportNodes.Add(airportNode);
            }
            return unReachableAirportNodes;
        }

        public static void depthFirstTraverseAirports(
            Dictionary<string, AirportNode> airportGraph, string airport,
            HashSet<string> visitedAirports)
        {
            if (visitedAirports.Contains(airport))
            {
                return;
            }
            visitedAirports.Add(airport);
            List<string> connections = airportGraph[airport].connections;
            foreach (string connection in connections)
            {
                depthFirstTraverseAirports(airportGraph, connection, visitedAirports);
            }
        }

        //T.C is O(A*(A+R)) and S.C is O(A) where A is the no of airports
        //and R is the number of routes		
        public static void markUnreachableAirportNodes(
            Dictionary<string, AirportNode> airportGraph,
                List<AirportNode> unReachableAirportNodes)
        {
            foreach (var airportNode in unReachableAirportNodes)
            {
                var airport = airportNode.airport;
                var unReachableConnections = new List<string>();
                depthFirstSearchAddUnReachableConnections(airportGraph, airport,
                                                                unReachableConnections, new HashSet<string>());
                airportNode.unReachableConnections = unReachableConnections;
            }
        }

        public static void depthFirstSearchAddUnReachableConnections(
        Dictionary<string, AirportNode> airportGraph, string airport,
        List<string> unReachableConnections, HashSet<string> visitedAirports)
        {
            if (airportGraph[airport].isReachable || visitedAirports.Contains(airport))
            {
                return;
            }
            visitedAirports.Add(airport);
            unReachableConnections.Add(airport);
            List<string> connections = airportGraph[airport].connections;
            foreach (string connection in connections)
            {
                depthFirstSearchAddUnReachableConnections(airportGraph, connection,
      unReachableConnections, visitedAirports);
            }
        }

        public static int getMinimumNumberOfNewConnections
            (Dictionary<string, AirportNode> airportGraph,
                    List<AirportNode> unReachableAirportNodes)
        {
            unReachableAirportNodes.Sort((a1, a2) => a2.unReachableConnections.Count
                                                                    - a1.unReachableConnections.Count);

            int numberOfNewConnections = 0;
            foreach (AirportNode airportNode in unReachableAirportNodes)
            {
                if (airportNode.isReachable)
                {
                    continue;
                }
                numberOfNewConnections++;
                foreach (string connection in airportNode.unReachableConnections)
                {
                    airportGraph[connection].isReachable = true;
                }
            }

            return numberOfNewConnections;
        }



        public class AirportNode
        {
            public string airport;
            public List<string> connections;
            public bool isReachable;
            public List<string> unReachableConnections;

            public AirportNode(string airport)
            {
                this.airport = airport;
                connections = new List<string>();
                isReachable = true;
                unReachableConnections = new List<string>();
            }
        }
    }
}
