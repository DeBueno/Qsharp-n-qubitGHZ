using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.GHZ
{
    class Driver
    {
        static void Main(string[] args)
        {
            using (var sim = new QuantumSimulator())
            {
                System.Console.WriteLine("N-Qubit GHZ entanglement");

                System.Console.WriteLine("Write a number of qubits to entangle (it's safe to not go above 20): ");
                var count = System.Convert.ToInt32(System.Console.ReadLine());

                System.Console.WriteLine($"Entangling {count} qubits");
                var res = GHZ.Run(sim, count).Result;
                if(res)
                    System.Console.WriteLine($"Success");
                else
                    System.Console.WriteLine($"Failed!");
            }
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }
}