﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;

namespace EMap.Gis.Symbology
{
    public abstract class FeatureSymbolizer : Symbolizer, IFeatureSymbolizer
    {
        public ScaleMode ScaleMode { get; set; } = ScaleMode.Symbolic;
    }
}