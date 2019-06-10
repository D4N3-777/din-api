﻿using Din.Domain.Clients.Abstractions;
using Din.Domain.Clients.Radarr.Interfaces;

namespace Din.Domain.Clients.Radarr.Concrete
{
    public class RadarrClientConfig : BaseClientConfig, IRadarrClientConfig
    {
        public string SaveLocation { get; set; }
    }
}
