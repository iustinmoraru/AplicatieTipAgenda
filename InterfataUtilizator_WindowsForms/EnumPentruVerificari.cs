using System;

namespace InterfataUtilizator_WindowsForms
{
    [Flags]
    public enum CodEroare
    {
        Corect = 0,
        NumeIncorect = 1,
        DataIncorecta = 2,
        DescriereIncorecta = 4,
        PrioritateIncorecta = 8,
        ZileIncorecte = 16
    }


    [Flags]
    public enum CodEroareUser
    {
        Corect = 0,
        NumeUserIncorect = 1,
        PrenumeUserIncorect = 2,
        GenIncorect = 4
    }
}
