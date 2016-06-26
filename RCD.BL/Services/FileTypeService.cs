using RCD.DAL;
using RCD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RCD.BL.Services
{
    public class FileTypeService
    {

        
        public static int AddFileType(FileType fileType)
        {
            return RepositoryFileType.SaveFileTypeInDb(fileType);
        }

        public static int GetFyleTypeId(string fileTypeName)
        {
            var fileTypeId = RepositoryFileType.GetFileTypeIdByName(fileTypeName);
            if (fileTypeId == 0)
            {
                FileType fileTypeObj = new FileType();

                fileTypeObj.Name = fileTypeName;
                fileTypeId = AddFileType(fileTypeObj);
            }
            return fileTypeId;
        }

        public static List<FileType> GetFileTypes()
        {
            return RepositoryFileType.GetFileTypes();
        }
    }
}
