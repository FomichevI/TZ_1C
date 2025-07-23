using UnityEngine;

public interface IFigureSorter
{
    IFigureHolder[] Holders { get; }

    void UpdateHolders();
}
