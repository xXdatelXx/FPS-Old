﻿namespace Source.Runtime.Tools.Math
{
    public interface ICurve
    {
        float Time { get; }
        float MaxValue { get; }
        float MinValue { get; }
        float this[float time] { get; }
    }
}