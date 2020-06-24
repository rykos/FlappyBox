﻿using System;
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
        void Build(Vector2 position, float size);
    }
}
