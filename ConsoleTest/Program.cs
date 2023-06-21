using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Configuration;
using Petabridge.Cmd.Host;
using Petabridge.Cmd.Cluster;
using Akka.Cluster;
using System.Threading;

namespace ConsoleTest
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Enter IP address:");
            string ipAddress = Console.ReadLine();

            Console.WriteLine("Enter port:");
            int port = int.Parse(Console.ReadLine());

            // Akka Configuration 생성
            var config = ConfigurationFactory.ParseString($@"
        akka {{
            actor.provider = cluster
            remote.dot-netty.tcp {{
                hostname = {ipAddress}
                port = {port}
            }}
        }}");

            // Actor System 생성
            var system = ActorSystem.Create("clusterSystem", config);

            // Cluster Status Actor 생성
            var clusterStatusActor = system.ActorOf(Props.Create(() => new ClusterStatusActor()), "clusterStatus");


            // 종료 시그널 대기
            await system.WhenTerminated;

            Thread.Sleep(10000);
            ;
        }
    }

    public class ClusterStatusActor : ReceiveActor
    {
        private readonly Cluster _cluster;

        public ClusterStatusActor()
        {
            _cluster = Cluster.Get(Context.System);
            _cluster.Subscribe(Self, typeof(ClusterEvent.IMemberEvent));

            Receive<ClusterEvent.CurrentClusterState>(state =>
            {
                var members = state.Members;
                Console.WriteLine($"---- Cluster Members ({members.Count}) ----");
                foreach (var member in members)
                {
                    Console.WriteLine($"Address: {member.Address}, Roles: [{string.Join(",", member.Roles)}], Status: {member.Status}");
                }
                Console.WriteLine($"---------------------------------------");
            });

            Receive<ClusterEvent.IMemberEvent>(memberEvent =>
            {
                Console.WriteLine($"Member: {memberEvent.Member.Address}, Roles: [{string.Join(",", memberEvent.Member.Roles)}], Event: {memberEvent.GetType().Name}");
            });
        }

        protected override void PreStart()
        {
            _cluster.Subscribe(Self, new[] { typeof(ClusterEvent.IMemberEvent) });
        }

        protected override void PostStop()
        {
            _cluster.Unsubscribe(Self);
        }
    }
}
