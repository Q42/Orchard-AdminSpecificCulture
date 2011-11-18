﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Orchard.Localization.Services;
using Orchard.ContentManagement;
using Orchard;
using System.Web;
using Orchard.Environment.Extensions;
using Q42.AdminSpecificCulture.Models;

namespace Q42.AdminSpecificCulture.Services
{
  public class AdminCultureSelector : ICultureSelector
  {
    private readonly IWorkContextAccessor _workContextAccessor;

    public AdminCultureSelector(IWorkContextAccessor workContextAccessor)
    {
      _workContextAccessor = workContextAccessor;
    }

    public CultureSelectorResult GetCulture(HttpContextBase context)
    {
      if (context == null || context.Request == null)
        return null;

      bool isAdmin = context.Request.Path.StartsWith("/Admin", StringComparison.OrdinalIgnoreCase);
      if (!isAdmin)return null;

      var settings = _workContextAccessor.GetContext().CurrentSite.As<AdminCultureSettingsPart>();
      if (settings == null) return null;
      
      string currentCultureName = settings.AdminCulture;
      if (string.IsNullOrEmpty(currentCultureName)) return null;

      return new CultureSelectorResult { Priority = 42, CultureName = currentCultureName };
    }
  }
}
