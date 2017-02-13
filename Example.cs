using System;
using Faxime.Common.Design;

public class FooManager : Singleton<FooManager>
{
    public float Foo { get; private set; }

    private FooManager()
    {
        Foo = 1.0F;
    }

    public void IncrementFoo()
    {
        Foo += 0.5F;
    }
}

public class Bar
{
    public Bar()
    {
        float bar = FooManager.Instance.Foo;

        FooManager.Instance.IncrementFoo();
        bar = FooManager.Instance.Foo;
    }
}