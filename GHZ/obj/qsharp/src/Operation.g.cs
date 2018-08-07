#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Quantum.GHZ", "Set (desired : Result, q0 : Qubit) : ()", new string[] { }, "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs", 159L, 7L, 5L)]
[assembly: OperationDeclaration("Quantum.GHZ", "GHZ (count : Int) : Bool", new string[] { }, "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs", 381L, 20L, 2L)]
#line hidden
namespace Quantum.GHZ
{
    public class Set : Operation<(Result,Qubit), QVoid>, ICallable
    {
        public Set(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Result,Qubit)>, IApplyData
        {
            public In((Result,Qubit) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits
            {
                get
                {
                    yield return Data.Item2;
                }
            }
        }

        String ICallable.Name => "Set";
        String ICallable.FullName => "Quantum.GHZ.Set";
        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        public override Func<(Result,Qubit), QVoid> Body => (__in) =>
        {
            var (desired,q0) = __in;
#line 10 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
            var current = M.Apply(q0);
#line 12 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
            if ((desired != current))
            {
#line 14 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
                MicrosoftQuantumPrimitiveX.Apply(q0);
            }

#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
        }

        public override IApplyData __dataIn((Result,Qubit) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Result desired, Qubit q0)
        {
            return __m__.Run<Set, (Result,Qubit), QVoid>((desired, q0));
        }
    }

    public class GHZ : Operation<Int64, Boolean>, ICallable
    {
        public GHZ(IOperationFactory m) : base(m)
        {
        }

        String ICallable.Name => "GHZ";
        String ICallable.FullName => "Quantum.GHZ.GHZ";
        protected Allocate Allocate
        {
            get;
            set;
        }

        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumPrimitiveCNOT
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get;
            set;
        }

        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected ICallable<(Result,Qubit), QVoid> Set
        {
            get;
            set;
        }

        public override Func<Int64, Boolean> Body => (__in) =>
        {
            var count = __in;
            //if all measurements ends the same, proving that the quantum system is indeed entangled, this variable stays true
#line 25 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
            var success = true;
            //defines a quantum system of 'count' qubits
#line 28 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
            var qubits = Allocate.Apply(count);
            //set initial state to |0>
#line 31 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
            foreach (var index in new Range(0L, (count - 1L)))
            {
#line 33 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
                Set.Apply((Result.Zero, qubits[index]));
            }

            //entangle
#line 36 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
            MicrosoftQuantumPrimitiveH.Apply(qubits[0L]);
#line 37 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
            foreach (var index in new Range(0L, (count - 2L)))
            {
#line 39 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
                MicrosoftQuantumPrimitiveCNOT.Apply((qubits[index], qubits[(index + 1L)]));
            }

            //check measurements
#line 42 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
            foreach (var index in new Range(0L, 2L, (count - 2L)))
            {
#line 44 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
                if ((M.Apply(qubits[index]) != M.Apply(qubits[(index + 1L)])))
                {
                    //for some reason it was not entangled!
#line 47 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
                    success = false;
                }
            }

            //set back to zero to exit
#line 51 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
            foreach (var index in new Range(0L, (count - 1L)))
            {
#line 53 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
                Set.Apply((Result.Zero, qubits[index]));
            }

#line hidden
            Release.Apply(qubits);
#line 56 "C:\\Users\\Daniel\\source\\repos\\GHZ\\GHZ\\Operation.qs"
            return success;
        }

        ;
        public override void Init()
        {
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.MicrosoftQuantumPrimitiveCNOT = this.Factory.Get<IUnitary<(Qubit,Qubit)>>(typeof(Microsoft.Quantum.Primitive.CNOT));
            this.MicrosoftQuantumPrimitiveH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.H));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.Set = this.Factory.Get<ICallable<(Result,Qubit), QVoid>>(typeof(Quantum.GHZ.Set));
        }

        public override IApplyData __dataIn(Int64 data) => new QTuple<Int64>(data);
        public override IApplyData __dataOut(Boolean data) => new QTuple<Boolean>(data);
        public static System.Threading.Tasks.Task<Boolean> Run(IOperationFactory __m__, Int64 count)
        {
            return __m__.Run<GHZ, Int64, Boolean>(count);
        }
    }
}