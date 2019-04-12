﻿using DiabloSharp.Endpoints;

namespace DiabloSharp
{
    public interface IDiabloApi
    {
        IAuthenticationScope CreateAuthenticationScope(); 

        ItemTypeEndpoint ItemType { get; }

        ItemEndpoint Item { get; }

        ActEndpoint Act { get; }
    }
}