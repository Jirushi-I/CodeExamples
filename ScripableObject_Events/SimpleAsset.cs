using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarAsset<T> : ScriptableObject
{
    [SerializeField] private T value;
    private HashSet<Refreshable> Refreshables;

    public void Update(T value)
    {
        this.value = value;
        
        foreach (var refreshable in Refreshables)
        {
            refreshable.Refresh();
        }
    }

    public T Get()
    {
        return value;
    }

    private void Register(Refreshable refreshable)
    {
	Refreshables.Add(refreshables);
    }

    private void Unregister(Refreshable refreshable)
    {
        if(Refreshables.Contains(refreshables))
	    Refreshables.Remove(refreshables);
        else
            Debug.Warning("Attepted to unregister a non-registered Refreshable");
    }
}