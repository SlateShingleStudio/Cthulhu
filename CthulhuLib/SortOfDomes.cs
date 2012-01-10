using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rhino;
using Rhino.Geometry;

namespace CthulhuLib
{
    public abstract class SortOfDomes
    {
        private Mesh mesh;
        private List<Line> edges;

        public Mesh Mesh
        {
            get { return mesh; }
            protected set { mesh = value; }
        }
        public List<Line> Edges
        {
            get { return edges; }
            protected set { edges = value; }
        }

        /// <summary>
        /// sort of domes solve routine... abstract here, different implementations there...
        /// </summary>
        /// <param name="aVecs"></param>
        /// <param name="aPt"></param>
        abstract public void solve(List<Vector3d> aVecs, Point3d aPt);
    }

    public class SortOfDomes1 : SortOfDomes {
        override public void solve(List<Vector3d> aVecs, Point3d aPt)
        {
            Mesh = new Mesh();
            Point3d p;
            int len = 2 * aVecs.Count;
            Point3d z = new Point3d(aPt.X, aPt.Y, aPt.Z - 5);

            List<Vector3d> pmVecs = new List<Vector3d>();

            pmVecs.AddRange(aVecs);

            foreach (Vector3d v in aVecs)
            {
                pmVecs.Add(new Vector3d(-1 * v.X, -1 * v.Y, v.Z));
            }

            len = pmVecs.Count;

            Mesh.Vertices.Add(aPt);

            // Add in rings of vertices;
            for (int i = 1; i <= len / 2; i++)
            {
                for (int j = 1; j <= len; j++)
                {
                    p = new Point3d(aPt);
                    for (int k = 0; k < i; k++)
                    {
                        p = p + pmVecs[(j + k) % len];
                    }
                    Mesh.Vertices.Add(p);
                }
            }
            //Add in Mesh faces

            //central ring

            for (int j = 1; j <= len; j++)
            {
                Mesh.Faces.AddFace(0, j % len + 1, j + len, j);
            }

            for (int i = 0; i < len / 2 - 2; i++)
            {
                for (int j = 1; j <= len; j++)
                {
                    Mesh.Faces.AddFace(j + i * len, j + (i + 1) * len, (j - 2 + len) % len + 1 + (i + 2) * len, (j - 2 + len) % len + 1 + (i + 1) * len);
                }
            }

            Mesh.Vertices.Add(z);

            Edges = new List<Line>();
            for (int i = 0; i < Mesh.TopologyEdges.Count; i++)
            {
                Edges.Add(Mesh.TopologyEdges.EdgeLine(i));
            }
        }
    }

    public class SortOfDomes2 : SortOfDomes
    {
        override public void solve(List<Vector3d> aVecs, Point3d aPt)
        {
            Mesh = new Mesh();
            Point3d p;
            int len = 2 * aVecs.Count;

            List<Vector3d> pmVecs = new List<Vector3d>();

            pmVecs.AddRange(aVecs);

            foreach (Vector3d v in aVecs)
            {
                pmVecs.Add(new Vector3d(-1 * v.X, -1 * v.Y, v.Z));
            }

            Mesh.Vertices.Add(aPt);

            // Add in rings of vertices;
            for (int i = 1; i <= len / 2; i++)
            {
                for (int j = 1; j <= len; j++)
                {
                    p = new Point3d(aPt);
                    for (int k = 0; k < i; k++)
                    {
                        p = p + pmVecs[(j + k) % len];
                    }
                    Mesh.Vertices.Add(p);
                }
            }
            //Add in Mesh faces

            //central ring
            for (int j = 1; j <= len; j++)
            {
                Mesh.Faces.AddFace(0, j % len + 1, j + len, j);
            }

            for (int i = 0; i < len / 2 - 2; i++)
            {
                for (int j = 1; j <= len; j++)
                {
                    Mesh.Faces.AddFace(j + i * len, j + (i + 1) * len, (j - 2 + len) % len + 1 + (i + 2) * len, (j - 2 + len) % len + 1 + (i + 1) * len);
                }
            }

            Edges = new List<Line>();
            for (int i = 0; i < Mesh.TopologyEdges.Count; i++)
            {
                Edges.Add(Mesh.TopologyEdges.EdgeLine(i));
            }
        }
    }
}
