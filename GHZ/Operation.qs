namespace Quantum.GHZ
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

    operation Set (desired: Result, q0: Qubit) : ()
    {
        body
        {
            let current = M(q0);

			if(desired != current)
			{
				X(q0);
			}
        }
    }
	//GHZ refers to an entangled state of n qubits
	operation GHZ (count : Int) : (Bool)
	{
		
		body
		{
			//if all measurements ends the same, proving that the quantum system is indeed entangled, this variable stays true
			mutable success = true;

			//defines a quantum system of 'count' qubits
			using(qubits = Qubit[count])
			{
				//set initial state to |0>
				for (index in 0..count-1)
				{
					Set(Zero, qubits[index]);
				}
				//entangle
				H(qubits[0]);
				for(index in 0..count-2)
				{
					CNOT(qubits[index], qubits[index+1]);
				}
				//check measurements
				for(index in 0..2..count-2)
				{
					if(M(qubits[index]) != M(qubits[index+1]))
					{
						//for some reason it was not entangled!
						set success = false;
					}
				}
				//set back to zero to exit
				for (index in 0..count-1)
				{
					Set(Zero, qubits[index]);
				}
			}
			return  success;
		}
	}
}
