﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EMap.Gis.Symbology
{
    public interface IPolygonSymbolizer:IFeatureSymbolizer
    {
        IList<IPolygonSymbol> Patterns { get; set; }
    }
}