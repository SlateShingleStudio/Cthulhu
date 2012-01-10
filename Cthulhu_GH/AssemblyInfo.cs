using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Grasshopper.Kernel;
using Cthulhu_GH.Properties;

namespace Cthulhu_GH
{
    public class AssemblyInfo : GH_AssemblyInfo
    {
        // fail after this date
        public const String assemblyName = "Cthulhu_GH";
        public const String assemblyAbbrev = "Cthulhu";
        public const String assemblyDescrip = "MultiDimensional Tiling for Grasshopper";
        public const String assemblyCategory = "Extra";
        public const String assemblySubCategory = "Cthulhu";
        public const System.Drawing.Bitmap assemblyIcon = null;
        public const String assemblyVersion = "0.0.0.1";
        public const String authorEmail = "info@slateshinglestudio.com";
        public const String authorName = "Brian Lockyear / Slate Shingle Studio";
        public const String authorSite = "www.slateshinglestudio.com";

        public AssemblyInfo() { }

        public override string AssemblyName { get { return assemblyName; } }
        public override string AssemblyDescription { get { return assemblyDescrip; } }
        public override System.Drawing.Bitmap AssemblyIcon { get { return assemblyIcon; } }

        static public GH_LibraryLicense License()
        {
            return GH_LibraryLicense.beta;
        }

        public override GH_LibraryLicense AssemblyLicense { get { return License(); } }

        public override string AssemblyVersion { get { return assemblyVersion; } }
        public override string AuthorContact { get { return authorEmail; } }
        public override string AuthorName { get { return authorName; } }
    }
}
