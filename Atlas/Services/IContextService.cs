﻿using Atlas.Domain;

namespace Atlas.Services
{
    public interface IContextService
    {
        Site CurrentSite();
        Member CurrentMember();
    }
}