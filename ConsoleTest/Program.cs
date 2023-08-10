using System;
using Akka.Actor;
using Akka.Cluster;

class Program
{
    static void Main(string[] args)
    {
        var config = @"
            akka {
                actor {
                    provider = ""Akka.Cluster.ClusterActorRefProvider, Akka.Cluster""
                }
                remote {
                    log-remote-lifecycle-events = off
                    dot-netty.tcp {
                        hostname = ""127.0.0.1""
                        port = 9100
                    }
                }
                cluster {
                    seed-nodes = [""akka.tcp://mls-cluster-system@127.0.0.1:9100""]
                }
            }";

        var system = ActorSystem.Create("mls-cluster-system", config);
        var cluster = Cluster.Get(system);

        var clusterWatcher = system.ActorOf(Props.Create(() => new ClusterWatcher()));

        while (true)
        {
            Console.WriteLine("Press ENTER to check the cluster status or type 'exit' to leave...");
            var input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                break;
            }

            clusterWatcher.Tell("CheckStatus");
        }

        cluster.Leave(cluster.SelfAddress);
        system.Terminate().Wait();


        Console.ReadLine();
    }
}

public class ClusterWatcher : ReceiveActor
{
    public ClusterWatcher()
    {
        var cluster = Cluster.Get(Context.System);

        Receive<string>(statusCheck => statusCheck == "CheckStatus", statusCheck =>
        {
            Console.WriteLine("Requesting cluster status...");
            cluster.SendCurrentClusterState(Self);
        });

        Receive<ClusterEvent.CurrentClusterState>(state =>
        {
            ShowClusterState(state);
        });
    }

    private void ShowClusterState(ClusterEvent.CurrentClusterState state)
    {
        Console.WriteLine("Cluster state:");
        Console.WriteLine("Members:");
        foreach (var member in state.Members)
        {
            Console.WriteLine($"\t{member.Address}: {member.Status}");
        }

        Console.WriteLine("Roles:");
        foreach (var role in state.AllRoles)
        {
            Console.WriteLine($"\t{role}");
        }
    }
}
