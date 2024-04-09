﻿using Microsoft.AspNetCore.Mvc;

namespace SkillReceive.Component
{
    public class MainMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
