using System.Collections.Generic;
using System.Reflection;

namespace Arys.EES.Wrappers;

public abstract class ReflectionWrapper<T>
{
    protected readonly Dictionary<string, MemberInfo> reflectionCache = [];

    public T Value { get; private set; }

    private protected ReflectionWrapper(T value)
    {
        Value = value;
    }
}
