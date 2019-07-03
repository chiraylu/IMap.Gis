﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EMap.Gis.Symbology
{
    public interface ILayerFactory
    {
        IBaseLayer OpenLayer(string dataPath);
    }
}
