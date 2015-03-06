using System;

namespace SampleAppPlus.Tests.Framework
{
    public class Constants
    {
        public const string FilePath = @"C:\SampleAppPlus\SampleAppPlus\bin\Debug\HappyFace.jpg";
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
