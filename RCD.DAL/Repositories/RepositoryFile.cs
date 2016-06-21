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

        //public static FileTypes GetFileById(int fileId)
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
                    //Add FileTypes object into FileTypes DBset
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
                            where (f.Name.Contains(searchedFile) || ft.Name.Contains(searchedFile) || m.Value.Contains(searchedFile))
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

        public static List<FileViewModel> SearchThroughDinamycQuery(string condition1, DateTime condition2, DateTime condition3)
        {
            ModelContext mContext = new ModelContext();
            IQueryable<Model.File> queryFiles = mContext.Files;
            IQueryable<FileType> queryFileType = mContext.FileTypes;
            IQueryable<Metadata> queryMetadata = mContext.Metadata;
            IQueryable<MetadataType> queryMetadataTypes = mContext.MetadataTypes;
            IQueryable<FileViewModel> resultQuery = null;

            if (condition1 != null || condition1 != "")
            {
                //resultQuery = from f in queryFiles
                //              join ft in queryFileType
                //              on f.FileType.FileTypeId equals ft.FileTypeId;
                              //Where(f => f.Name == condition1)
            }


                return null;
        }

        public static List<FileViewModel> SearchFileByDatePicker(DateTime dateFrom, DateTime dateTo)
        {
            using (var context = new ModelContext())
            {
                try
                {
                    return (from f in context.Files
                            join ft in context.FileTypes
                            on f.FileType.FileTypeId equals ft.FileTypeId
                            where f.CreateDate >= dateFrom && f.CreateDate <= dateTo
                            select new FileViewModel {
                                FileId = f.FileId,
                                FileName = f.Name,
                                FileType = f.FileType.Name,
                                CreationDate = f.CreateDate
                            }).Distinct().ToList();
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
