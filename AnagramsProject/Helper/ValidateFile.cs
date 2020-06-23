using System;
using System.IO;

namespace AnagramsProject.Helper
{
    public class ValidateFile
    {
        public static bool FileExist(string FileName)
        {
            bool Result = false;
            try
            {
                if (File.Exists(FileName))
                {
                    Result = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Result;
        }
    }
}
