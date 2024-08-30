
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiModels = HexedSceneryApiClient.Models;
using ViewModels = HexedSceneryMobileApp.Models;

namespace HexedSceneryMobileApp.Helpers
{
    public static class Extensions
    {
        public static ViewModels.Menu ToViewModel(this ApiModels.Menu source)
        {
            var model = new ViewModels.Menu();
            model.Title = source.Title;

            if (source.Groups != null && source.Groups.Any())
            {
                model.Groups = new List<ViewModels.MenuGroup>();
                foreach (var sGroup in source.Groups)
                {
                    model.Groups.Add(sGroup.ToViewModel());
                }
            }
            if (source.Items != null && source.Items.Any())
            {
                model.Items = new List<ViewModels.MenuItem>();
                foreach(var sItem in source.Items)
                {
                    model.Items.Add(sItem.ToViewModel());
                }
            }

            return model;
        }

        public static ViewModels.MenuGroup ToViewModel(this ApiModels.MenuGroup source)
        {
            var model = new ViewModels.MenuGroup();
            model.Id = source.Id;
            model.DisplayText = source.DisplayText;

            if (source.Groups != null && source.Groups.Any())
            {
                model.Groups = new List<ViewModels.MenuGroup>();
                foreach (var sGroup in source.Groups)
                {
                    model.Groups.Add(sGroup.ToViewModel());
                }
            }
            if (source.Items != null && source.Items.Any())
            {
                model.Items = new List<ViewModels.MenuItem>();
                foreach (var sItem in source.Items)
                {
                    model.Items.Add(sItem.ToViewModel());
                }
            }

            return model;
        }

        public static ViewModels.MenuItem ToViewModel(this ApiModels.MenuItem source)
        {
            var model = new ViewModels.MenuItem();
            model.Id = source.Id;
            model.DisplayText = source.DisplayText;
            return model;
        }
    }
}
