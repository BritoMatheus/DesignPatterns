using System;

namespace DesignPattern.Prototype
{
    public interface ICloneable<T>
    {
        T Clone();
    }
}