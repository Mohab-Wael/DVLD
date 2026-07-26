using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Classes
{
    public class clsUtil
    {

        public static string GenerateGuid()
        {
            Guid NewGuid = Guid.NewGuid();

            return NewGuid.ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show("Error Creating Folder" + ex.Message);
                        return false;
                    }
                }


            }

            return true;


        }

        public static string ReplaceFileNameWithGuid(string sourceFile)
        {
            string FileName = sourceFile;
            FileInfo fi = new FileInfo(FileName);
            return GenerateGuid() + fi.Extension;
        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {

            string DestinationFolder = @"C:\DVLD-People-Images\";

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string DestinationFile = DestinationFolder + ReplaceFileNameWithGuid(sourceFile);

            try
            {
                File.Copy(sourceFile, DestinationFile, true);
            }
            catch(IOException iox)
            {
                MessageBox.Show(iox.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            sourceFile = DestinationFile;
            return true;        
        }



    }
}
