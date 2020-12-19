using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;
using Skclusive.Script.DomHelpers;
using System;

namespace Skclusive.Material.Popper
{
    public class PopperHelper : IAsyncDisposable
    #if NETSTANDARD2_0
        , IDisposable
    #endif
    {
        public PopperHelper(IScriptService scriptService)
        {
            ScriptService = scriptService;
        }

        private object Id;

        private IScriptService ScriptService { get; }

        public async ValueTask InitAsync(ElementReference? containerRef, ElementReference? popperRef, PopperOptions options)
        {
            Id = await ScriptService.InvokeAsync<object>("Skclusive.Material.Popper.PopperHelper.construct", containerRef, popperRef, options);
        }

        public async ValueTask UpdateAsync()
        {
            if (Id != null)
            {
                await ScriptService.InvokeVoidAsync("Skclusive.Material.Popper.PopperHelper.update", Id);
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (Id != null)
            {
                await ScriptService.InvokeVoidAsync("Skclusive.Material.Popper.PopperHelper.dispose", Id);

                Id = null;
            }
        }

        public bool Active => Id != null;

#if NETSTANDARD2_0

        void IDisposable.Dispose()
        {
            if (this is IAsyncDisposable disposable)
            {
                _ = disposable.DisposeAsync();
            }
        }

#endif
    }
}