using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Controllers.Map
{
    public interface INode
    {
        float Size { get; }
        IController Controller { get; }
        void Build(Vector2 position, float size);
    }

    [System.Serializable]
    public class NodeSettings 
    {
        public float PlayerHorizontalSpeed;
        public float PlayerVerticalSpeed;
    }
}
