using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurnBasedPractice.GameClasses
{
    public abstract class WrapperAbstract
    {

        abstract public int NextID();
        abstract public void reload();
        abstract public void saveCacheChanges();

    }
}
