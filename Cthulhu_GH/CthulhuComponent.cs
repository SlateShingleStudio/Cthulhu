using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Rhino;
using Grasshopper;
using Grasshopper.Kernel;
using Cthulhu_GH.Properties;

namespace Cthulhu_GH
{
    public abstract class CthulhuComponent : GH_Component
    {
        protected Bitmap icon = Resources.Icons_02;
        protected bool hidden = false;

        // std defs for GH_Component overrides
        protected override Bitmap Icon { get { return icon; } }

        // access to rhino model
        protected static RhinoDoc Doc { get { return Rhino.RhinoDoc.ActiveDoc; }}

        // components hidden because they are obsolete or whatever...
        public override GH_Exposure Exposure
        {
            get
            {
                return hidden ? GH_Exposure.hidden : base.Exposure;
            }
        }

        public CthulhuComponent(String aName, String aAbbrev, String aDescrip
            )
            : base(
            aName, 
            aAbbrev, 
            aDescrip, 
            AssemblyInfo.assemblyCategory,
            AssemblyInfo.assemblySubCategory)
        {
        }

        sealed protected override void SolveInstance(IGH_DataAccess DA)
        {
            TstValidLicense();
            Solve(DA);
        }

        protected abstract void Solve(IGH_DataAccess DA);

        protected bool TstValidLicense()
        {
            if (AssemblyInfo.License() == GH_LibraryLicense.expired)
            {
                throw new Cthulhu_InvalidLicense();
            }
            else
            {
                return true;
            }
        }
    }
}
