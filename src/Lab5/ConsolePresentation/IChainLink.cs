﻿namespace ConsolePresentation;

public interface IChainLink<TRequest, TResult>
{
    TResult Handle(TRequest request);

    IChainLink<TRequest, TResult> AddNext(IChainLink<TRequest, TResult> link);
}