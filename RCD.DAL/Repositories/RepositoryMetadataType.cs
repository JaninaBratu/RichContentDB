﻿using RCD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.DAL.Repositories
{
    public class RepositoryMetadataType
    {

        public static int SaveMetadataTypeInDb(MetadataType metaType)
        {
            using (var context = new ModelContext())
                try
                {
                    context.MetadataTypes.Add(metaType);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

                return metaType.MetadataTypeId;
        }

        //new added
        public static List<int> GetMetadataType(string metadataType, int fileId)
        {
            List<int> resultList = new List<int>();

            using (var context = new ModelContext())
            {
                var countMetaType = (from mt in context.MetadataTypes
                         where mt.Name == metadataType
                         select mt.MetadataTypeId).Count();

                var countFile = (from f in context.Files
                                  where f.FileId == fileId
                                  select f.FileId).Count();

                resultList.Add(countMetaType);
                resultList.Add(countFile);
            }
            return resultList;
        }
        //end

        public static int GetMetadataTypeByName(string metaType)
        {
            int metadataTypeId;
            using (var context = new ModelContext())
            {

                try
                {
                    metadataTypeId = context.MetadataTypes
                               .Where(m => m.Name == metaType)
                               .Select(m => m.MetadataTypeId)
                               .FirstOrDefault();

                }
                catch (Exception)
                {
                    metadataTypeId = -1;
                }

            }

            return metadataTypeId;
        }

    }
}
