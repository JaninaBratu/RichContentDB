using RCD.DAL.ViewModel;
using RCD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.DAL.Repositories
{
    public class RepositoryMetadata
    {

        public static List<Metadata> GetMetadataByType(int metadataTypeId)
        {
            using (var context = new ModelContext())
            {

                try
                {
                    return (from m in context.Metadata
                            where m.MetadataType.MetadataTypeId == metadataTypeId
                            select m).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static void SaveMetadataToDb(Metadata metadata, int metadataId, int fileId)
        { 
            using (var context = new ModelContext())
            {
                try
                {
                    metadata.MetadataType = context.MetadataTypes.FirstOrDefault(m => m.MetadataTypeId == metadataId);
                    metadata.File = context.Files.FirstOrDefault(f => f.FileId == fileId);

                    context.Metadata.Add(metadata);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<Metadata> GetAllMetadataFiles()
        {
            using (var context = new ModelContext())
            {
                try
                {
                    return (from f in context.Files
                            join m in context.Metadata
                            on f.FileId equals m.FileId
                            join mt in context.MetadataTypes
                            on m.MetadataTypeId equals mt.MetadataTypeId
                            select m).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        //added
        public static List<int> GetListOfMetadataId(string nameOfMetadata, string metadataOfValue)
        {
            List<int> listOfId = new List<int>();

            using (var context = new ModelContext())
            {

                try
                {
                    listOfId.Add(context.Metadata
                               .Where(m => m.Value == metadataOfValue)
                               .Select(m => m.MetadataId)
                               .FirstOrDefault());


                    listOfId.Add(context.MetadataTypes
                               .Where(mt => mt.Name == nameOfMetadata)
                               .Select(mt => mt.MetadataTypeId)
                               .FirstOrDefault());
                }
                catch (Exception)
                {
                    throw;
                }

            }

            if (listOfId.Count ==2 )
            {
                return listOfId;
            }
            else
            {
                return null;
            }
            
        }
        //end
    }
}
