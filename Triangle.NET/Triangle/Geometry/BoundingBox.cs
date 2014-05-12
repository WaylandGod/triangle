﻿// -----------------------------------------------------------------------
// <copyright file="BoundingBox.cs" company="">
// Triangle.NET code by Christian Woltering, http://triangle.codeplex.com/
// </copyright>
// -----------------------------------------------------------------------

namespace TriangleNet.Geometry
{
    using System;

    /// <summary>
    /// A simple bounding box class.
    /// </summary>
    public class BoundingBox
    {
        double xmin, ymin, xmax, ymax;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingBox" /> class.
        /// </summary>
        public BoundingBox()
            : this(double.MaxValue, double.MaxValue, -double.MaxValue, -double.MaxValue)
        {
        }

        public BoundingBox(BoundingBox other)
            : this(other.MinX, other.MinY, other.MaxX, other.MaxY)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingBox" /> class
        /// with predefined bounds.
        /// </summary>
        /// <param name="xmin">Minimum x value.</param>
        /// <param name="ymin">Minimum y value.</param>
        /// <param name="xmax">Maximum x value.</param>
        /// <param name="ymax">Maximum y value.</param>
        public BoundingBox(double xmin, double ymin, double xmax, double ymax)
        {
            this.xmin = xmin;
            this.xmax = xmax;
            this.ymin = ymin;
            this.ymax = ymax;
        }

        /// <summary>
        /// Gets the minimum x value (left boundary).
        /// </summary>
        public double MinX
        {
            get { return xmin; }
        }

        /// <summary>
        /// Gets the maximum x value (right boundary).
        /// </summary>
        public double MaxX
        {
            get { return xmax; }
        }

        /// <summary>
        /// Gets the minimum y value (bottom boundary).
        /// </summary>
        public double MinY
        {
            get { return ymin; }
        }

        /// <summary>
        /// Gets the maximum y value (top boundary).
        /// </summary>
        public double MaxY
        {
            get { return ymax; }
        }

        /// <summary>
        /// Gets the width of the bounding box.
        /// </summary>
        public double Width
        {
            get { return xmax - xmin; }
        }

        /// <summary>
        /// Gets the height of the bounding box.
        /// </summary>
        public double Height
        {
            get { return ymax - ymin; }
        }

        /// <summary>
        /// Scale bounds.
        /// </summary>
        /// <param name="dx">Add dx to left and right bounds.</param>
        /// <param name="dy">Add dy to top and bottom bounds.</param>
        public void Resize(double dx, double dy)
        {
            xmin -= dx;
            xmax += dx;
            ymin -= dy;
            ymax += dy;
        }

        /// <summary>
        /// Expand rectangle to include given point.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public void Expand(double x, double y)
        {
            xmin = Math.Min(xmin, x);
            ymin = Math.Min(ymin, y);
            xmax = Math.Max(xmax, x);
            ymax = Math.Max(ymax, y);
        }

        /// <summary>
        /// Expand rectangle to include given rectangle.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public void Expand(BoundingBox other)
        {
            xmin = Math.Min(xmin, other.xmin);
            ymin = Math.Min(ymin, other.ymin);
            xmax = Math.Max(xmax, other.xmax);
            ymax = Math.Max(ymax, other.ymax);
        }

        /// <summary>
        /// Check if given point is inside bounding box.
        /// </summary>
        /// <param name="pt">Point to check.</param>
        /// <returns>Return true, if bounding box contains given point.</returns>
        public bool Contains(Point pt)
        {
            return ((pt.x >= xmin) && (pt.x <= xmax) && (pt.y >= ymin) && (pt.y <= ymax));
        }

        public bool Contains(BoundingBox other)
        {
            return (xmin <= other.MinX && other.MaxX <= xmax
                && ymin <= other.MinY && other.MaxY <= ymax);
        }

        public bool Intersects(BoundingBox other)
        {
            return (other.MinX < xmax && xmin < other.MaxX
                && other.MinY < ymax && ymin < other.MaxY);
        }
    }
}
