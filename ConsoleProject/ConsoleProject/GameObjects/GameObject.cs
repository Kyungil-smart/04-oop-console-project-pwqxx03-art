using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class GameObject
{
    public string Symbol { get; set; }
    public Vector Position { get; set; }

    public virtual void Render() { }
}

