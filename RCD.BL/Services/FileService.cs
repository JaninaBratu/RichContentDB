using RCD.BL.Utils;
using RCD.DAL;
using RCD.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;


namespace RCD.BL.Services
{
    public class FileService
    {
    
        public static void AddFile(string destinationFile)
        {
            Util.Log(String.Format("File Created:14 "));
            var fileInfo = new FileInfo(destinationFile);
            
            var file = new Model.File();
            file.Name = fileInfo.Name;
            file.Path = destinationFile;
          
            //added
            file.CreateDate = fileInfo.CreationTime;
            //end

            Util.Log(String.Format("File Created:15 "));
            var fileId = RepositoryFile.SaveFileInDb(file, GetFileExtensionId(fileInfo));
            Util.Log(String.Format("File Created:16 "));
            //MetadataService.AddMetadata(fileInfo, fileId);
            Util.Log(String.Format("File Created:17 "));
        }

        public static List<Model.File> GetFileInfo(int fileId)
        {
            return RepositoryFile.GetFileInfo(fileId);
        }

        private static int GetFileExtensionId(FileInfo fileInfo)
        {
            string extension = Util.GetFileExtension(fileInfo.FullName);
            return FileTypeService.GetFyleTypeId(extension);
        }

        public static List<DAL.ViewModel.FileViewModel> GetFileDetails()
        {
            return RepositoryFile.GetFileDetails();
        }

        public static List<DAL.ViewModel.FileViewModel> SearchFile(string searchedFile)
        {
            return RepositoryFile.SearchFile(searchedFile);
        }

        public static Model.File GetFile(int fileName)
        {
            return RepositoryFile.GetFile(fileName);
        }

        //public static File GetFileById(int fileId)
        //{
        //    return RepositoryFile.GetFileById(fileId);
        //}

        public static List<Model.File> SearchFileByDatePicker(DateTime dateFrom, DateTime dateTo)
        {
            return RepositoryFile.SearchFileByDatePicker(dateFrom, dateTo);
        }
    }
}
