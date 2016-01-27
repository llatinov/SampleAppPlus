using System;
using System.IO;

namespace SampleAppPlus.Tests.Framework
{
    public class Constants
    {
        public static string CurrentPath
        {
            get { return Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar; }
        }
        public static string FilePath
        {
            get { return CurrentPath + "HappyFace.jpg"; }
        }
    }

    public enum Messages
    {
        [StringValue("Problem occured, try again later")]
        ProblemOccured,
        [StringValue("Successfully done")]
        Success
    }

    public enum Text
    {
        [StringValue("File Name")]
        TableHeader
    }
}
