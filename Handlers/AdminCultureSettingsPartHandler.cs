using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;
using Q42.AdminSpecificCulture.Models;

namespace Q42.AdminSpecificCulture.Handlers
{

  public class AdminCultureSettingsPartHandler : ContentHandler
  {

    // contenthandler: http://www.orchardproject.net/docs/Understanding-content-handlers.ashx

    public AdminCultureSettingsPartHandler(IRepository<AdminCultureSettingsPartRecord> repository)
    {
      Filters.Add(new ActivatingFilter<AdminCultureSettingsPart>("Site"));
      Filters.Add(StorageFilter.For(repository));
    }

  }

}