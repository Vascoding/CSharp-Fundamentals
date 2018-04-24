using System;

public class TyreFactory
{
    public static UltrasoftTyre CreateUltraSoft(double hardness, double grip)
    {
        return new UltrasoftTyre(hardness, grip);
    }
    public static HardTyre CreateHard(double hardness)
    {
        return new HardTyre(hardness);
    }
}

