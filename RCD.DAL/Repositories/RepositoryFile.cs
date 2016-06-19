using RCD.DAL.ViewModel;
using RCD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace RCD.DAL
{
    public class RepositoryFile
    {

        public static List<Model.File> GetFileAndMetadata()
        {
            try
            {
                using (var context = new ModelContext())
                {
                    return context.Files
                              .Include("Metadata.MetadataType")
                              .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ViewModel.FileViewModel> GetFileDetails()
        {
            try
            {
                using (var context = new ModelContext())
                {
                    return (from f in context.Files
                            join ft in context.FileTypes on f.FileType.FileTypeId equals ft.FileTypeId
                            select new ViewModel.FileViewModel
                            {
                                FileId = f.FileId,
                                FileName = f.Name,
                                FileType = f.FileType.Name,
                                CreationDate = f.CreateDate
                            }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Model.File> GetFileInfo(int fileId)
        {
            using (var cnt = new ModelContext())
            {
                var result = (from f in cnt.Files.Include("Metadata.MetadataType").Include("FileType")
                              where f.FileId == fileId
                              select f).ToList();
                return result; 
            }
        }

        //public static File GetFileById(int fileId)
        //{
        //    using (var context = new ModelContext())
        //    {
        //        return (from f in context.Files
        //                join m in context.Metadata
        //                on f.FileId equals m.FileId
        //                join mt in context.MetadataTypes
        //                on m.MetadataTypeId equals mt.MetadataTypeId
        //                where m.Value == valueOfMetadata && mt.Name == nameOfMetadata
        //                select f);
        //    }
                
        //}

        public static int SaveFileInDb(Model.File file, int extensionId)
        {
            //create DBContext object
            using (var context = new ModelContext())
            {
                try
                {
                    file.User = context.Users.FirstOrDefault(usr => usr.UserId == 1);
                    file.FileType = context.FileTypes.FirstOrDefault(ft => ft.FileTypeId == extensionId);
                    //Add File object into File DBset
                    context.Files.Add(file);

                    // call SaveChanges method to save type into database
                    context.SaveChanges();
                    return file.FileId;
                }
                catch (Exception)
                {

                    return 0;
                }
            }
        }

        public static List<ViewModel.FileViewModel> SearchFile(string searchedFile)
        {
            using (var context = new ModelContext())
            {
                try
                {
                    return (from f in context.Files
                            join ft in context.FileTypes
                            on f.FileType.FileTypeId equals ft.FileTypeId
                            join m in context.Metadata
                            on f.FileId equals m.FileId
                            join mt in context.MetadataTypes
                            on m.MetadataTypeId equals mt.MetadataTypeId
                            where f.Name.Contains(searchedFile) || ft.Name.Contains(searchedFile) || m.Value.Contains(searchedFile)
                            select new FileViewModel
                            {
                                FileId = f.FileId,
                                FileName = f.Name,
                                FileType = f.FileType.Name
                            }).Distinct().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static List<Model.File> SearchFileByDatePicker(DateTime dateFrom, DateTime dateTo)
        {
            using (var context = new ModelContext())
            {
                try
                {
                    return (from f in context.Files
                            join ft in context.FileTypes
                            on f.FileType.FileTypeId equals ft.FileTypeId
                            where f.CreateDate >= dateFrom && f.CreateDate <= dateTo
                            select f).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
            }
                
        }

        public static Model.File GetFile(int fileId)
        {
            using (var context = new ModelContext())
            {
                try
                {
                    return context.Files.FirstOrDefault(f => f.FileId == fileId); 
                    
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
