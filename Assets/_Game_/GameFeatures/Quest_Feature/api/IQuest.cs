using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuest 
{
    bool IsDone { get; }
    string Name { get; }
    string Description { get; }

}
