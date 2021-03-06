﻿using System;
using Model.Entities;
using Model.Interfaces;

namespace API.Features.Account.Services {
    public class AuthenticatedIdentityProvider : IAuthenticatedIdentityProvider {
        public Guid AuthenticatedUserId { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public string AuthenticatedUserEmail { get; private set; }
        public void SetAuthenticatedUser(NnaUser user) {
            if (user == null) throw new ArgumentNullException(nameof(user));

            IsAuthenticated = true;
            AuthenticatedUserId = user.Id;
            AuthenticatedUserEmail = user.Email;
        }

        public void ClearAuthenticatedUserInfo() {
            AuthenticatedUserId = Guid.Empty;
            IsAuthenticated = false;
            AuthenticatedUserEmail = string.Empty;
        }
    }
}
