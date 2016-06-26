using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCD.Model;

namespace RCD.DAL
{
    public class RepositoryFileType
    {

        public static int SaveFileTypeInDb(FileType fileType)
        {
            //create DBContext object
            using (var context = new ModelContext())
            {
                try
                {
                    //Add Type object into FileTypes DBset
                    context.FileTypes.Add(fileType);

                    // call SaveChanges method to save type into database
                    context.SaveChanges();
                   
                }
                catch (Exception)
                {
                    throw;
                }

                return fileType.FileTypeId;
            }

        }

        public static int GetFileTypeIdByName(string fileType)
        {
            int fileTypeId;
            using (var context = new ModelContext())
            {

                try
                {
                    fileTypeId = context.FileTypes
                               .Where(f => f.Name == fileType)
                               .Select(f => f.FileTypeId)
                               .FirstOrDefault();

                }
                catch (Exception)
                {
                    fileTypeId = -1;
                }

            }

            return fileTypeId;
        }

        public static List<string> GetFileTypes()
        {
            using (var context = new ModelContext())
            {
                return (from ft in context.FileTypes
                        select ft.Name).Distinct().ToList();
            }
        }

    }
}
