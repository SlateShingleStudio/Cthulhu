using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Grasshopper.Kernel;
using Cthulhu_GH.Properties;
using Rhino;
using Rhino.Geometry;
using CthulhuLib;

namespace Cthulhu_GH
{
    public abstract class SortOfDomes_GH : CthulhuComponent
    {
        /// <summary>
        ///  must load with correct solver in sub classes...
        /// </summary>
        static protected SortOfDomes solver;

        public SortOfDomes_GH(String aName, String aAbbrev, String aDescrip, SortOfDomes aSolver)
            : base(
                aName,
                aAbbrev,
                aDescrip
            )
        {
            solver = aSolver;
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.Register_VectorParam("Vectors", "Vecs", "Control vectors", GH_ParamAccess.list);
            pManager.Register_PointParam(
                "Destination",
                "Pt",
                "Point around which to construct destination mesh",
                new Point3d(0.0, 0.0, 0.0),
                GH_ParamAccess.item);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.Register_StringParam("Info", "I", "Information");
            pManager.Register_MeshParam("Mesh", "M", "Constructed Mesh");
            pManager.Register_LineParam("Edges", "E", "Constructed Edges");
        }

        protected override void Solve(IGH_DataAccess DA)
        {
            StringBuilder InfoStr = new StringBuilder();
            List<Vector3d> Vectors = new List<Vector3d>();
            Point3d Pt = new Point3d();

            try
            {
                // load parameters.  problem?  throw exception...
                if ((!DA.GetDataList("Vectors", Vectors)) || (!DA.GetData("Destination", ref Pt)))
                {
                    throw new UnsetParam();
                }
            }
            catch (UnsetParam Unset)
            {
                DA.SetData("Info", Unset.Message);
                return;
            }
            catch (Exception Expt)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, Expt.Message);
                return;
            }

            // calculations
            solver.solve(Vectors, Pt);

            // return results
            DA.SetData("Mesh", solver.Mesh);
            DA.SetDataList("Edges", solver.Edges);

            // set info line
            DA.SetData("Info", "Here's the info!");
        }
    }


    public class SortOfDomes1_GH : SortOfDomes_GH
    {
        public SortOfDomes1_GH()
            : base(
                "Cthulhu SortOfDomes 1",
                "Cthulhu1",
                "Edmund's First SortOfDomes routine implemented in a Cthulhu module",
                new SortOfDomes1())
        { }

        public override Guid ComponentGuid
        {
            get { return new Guid("F2A5EBE3-1BD5-4F9E-A234-0E1C7B6BE68B"); }
        }
    }

    public class SortOfDomes2_GH : SortOfDomes_GH
    {
        public SortOfDomes2_GH()
            : base(
                "Cthulhu SortOfDomes 2",
                "Cthulhu2",
                "Edmund's First SortOfDomes routine implemented in a Cthulhu module",
                new SortOfDomes2())
        { }

        public override Guid ComponentGuid
        {
            get { return new Guid("23026F5A-F475-4AB8-AE33-82F7AE7254C8"); }
        }
    }
}
