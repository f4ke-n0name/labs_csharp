﻿namespace ConsolePresentation;

public abstract class ChainLinkBase<TRequest, TResult> : IChainLink<TRequest, TResult>
{
    protected IChainLink<TRequest, TResult>? Next { get; private set; }

    public abstract TResult Handle(TRequest request);

    public IChainLink<TRequest, TResult> AddNext(IChainLink<TRequest, TResult> link)
    {
        if (Next is not null)
            return Next.AddNext(link);

        Next = link;
        return link;
    }
}