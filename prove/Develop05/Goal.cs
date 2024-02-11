using System;
using System.Collections.Generic;
using System.IO;

// Base class 
abstract class Goal
{
    public string _shortName;
    public string _description;
    public int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}