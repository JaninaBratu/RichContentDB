using RCD.DAL.Repositories;
using RCD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.BL.Services
{
    public class MetadataTypeService
    {

        public static int AddMetadataType(MetadataType metaType)
        {
            return RepositoryMetadataType.SaveMetadataTypeInDb(metaType);
        }


        public static int GetMetadataTypeById(string metadataTypeName)
        {
            var metadataTypeId = RepositoryMetadataType.GetMetadataTypeByName(metadataTypeName);
            if (metadataTypeId == 0)
            {
                MetadataType metaTypeObj = new MetadataType();

                metaTypeObj.Name = metadataTypeName;
                metadataTypeId = AddMetadataType(metaTypeObj);
            }
            return metadataTypeId;
        }

        public static int GetMetadataTypeByName(string metaType)
        {
            return RepositoryMetadataType.GetMetadataTypeByName(metaType);
        }


    }
}
