﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atlas.Client.Services;
using Atlas.Models.Public;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Atlas.Client.Components.Pages
{
    public abstract class PageBase : ComponentBase
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public ApiService ApiService { get; set; }

        [CascadingParameter] 
        protected CurrentSiteModel Site { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Site == null)
            {
                Site = await ApiService.GetFromJsonAsync<CurrentSiteModel>("api/public/current-site");
                await JsRuntime.InvokeVoidAsync("changePageTitle", Site.Title);
            }
        }

        protected RenderFragment AddComponent(string name, Dictionary<string, object> models = null) => builder =>
        {
            var type = Type.GetType($"Atlas.Client.Themes.{Site.Theme}.{name}Component, {typeof(Program).Assembly.FullName}");

            builder.OpenComponent(0, type);

            if (models != null)
            {
                for (var i = 0; i < models.Count; i++)
                {
                    var (key, value) = models.ElementAt(i);
                    builder.AddAttribute(i + 1, key, value);
                }
            }
            
            builder.CloseComponent();
        };
    }
}