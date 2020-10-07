﻿using EM.GIS.Data;
using EM.GIS.Geometries;
using OSGeo.OGR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Threading;


namespace EM.GIS.Symbology
{
    public class Group : BaseLayer, IGroup
    {
        public ILayerCollection Layers { get; }

        public Group()
        {
            Layers = new LayerCollection()
            {
                Parent=this
            };
        }
        protected override void OnDraw(Graphics graphics, Rectangle rectangle, IExtent extent, bool selected = false, CancellationTokenSource cancellationTokenSource = null)
        {
            var visibleLayers = Layers.Where(x => x.GetVisible(extent, rectangle));
            foreach (var layer in visibleLayers)
            {
                layer?.Draw(graphics, rectangle, extent, selected,  cancellationTokenSource);
            }
        }
        public override IExtent Extent 
        {
            get
            {
                IExtent extent = new Extent();
                for (int i = 0; i < Layers.Count; i++)
                {
                    var layer = Layers[i];
                    if (i == 0)
                    {
                        extent.MinX = layer.Extent.MinX;
                        extent.MinY = layer.Extent.MinY;
                        extent.MaxX = layer.Extent.MaxX;
                        extent.MaxY = layer.Extent.MaxY;
                    }
                    else
                    {
                        extent.MinX = Math.Min(extent.MinX, layer.Extent.MinX);
                        extent.MinY = Math.Min(extent.MinY, layer.Extent.MinY);
                        extent.MaxX = Math.Max(extent.MaxX, layer.Extent.MaxX);
                        extent.MaxY = Math.Max(extent.MaxY, layer.Extent.MaxY);
                    }
                }
                return extent;
            }
        }
    }
}