﻿using SocialMedia.Domain.DTO;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Interfaces.Factories
{
    public interface IPostFactory
    {
        Post CreatePost(string content, int authorUserId);
        Post CreateRepost(int originalPostId, int authorUserId);
    }
}
