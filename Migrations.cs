using System.Data;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Q42.AdminSpecificCulture.Models;

namespace Q42.AdminSpecificCulture
{
  public class Migrations : DataMigrationImpl
  {

    public int Create()
    {
      SchemaBuilder.CreateTable(typeof(AdminCultureSettingsPartRecord).Name, table => table
        .ContentPartRecord()
        .Column("AdminCulture", DbType.String)
      );

      ContentDefinitionManager.AlterPartDefinition(typeof(AdminCultureSettingsPartRecord).Name, part => part.Attachable(false));

      return 1;
    }

  }
}