using System;
using DS.CodeSignal.IvPrep.DPBasic;
using DS.CodeSignal.IvPrep.Trees;

namespace DS.CodeSignal
{
    public class CodeSignalProgram
    {
        public static void Run()
        {
            var arr = new[] {0, 1};
            var str =
                "123";

            // Console.WriteLine(str.Length);
            var result = MapDecodingProblem.MapDecoding(str);
            
            Console.WriteLine(result);
        }
    }
}