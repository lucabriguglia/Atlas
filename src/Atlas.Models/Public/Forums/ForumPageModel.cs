﻿using System;

namespace Atlas.Models.Public.Forums
{
    public class ForumPageModel
    {
        public ForumModel Forum { get; set; } = new ForumModel();

        public PaginatedData<TopicModel> Topics { get; set; } = new PaginatedData<TopicModel>();

        public bool CanRead { get; set; }
        public bool CanStart { get; set; }

        public class ForumModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Slug { get; set; }
        }

        public class TopicModel
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Slug { get; set; }
            public int TotalReplies { get; set; }
            public Guid MemberId { get; set; }
            public string MemberDisplayName { get; set; }
            public DateTime TimeStamp { get; set; }
            public string GravatarHash { get; set; }
            public DateTime MostRecentTimeStamp { get; set; }
            public Guid MostRecentMemberId { get; set; }
            public string MostRecentMemberDisplayName { get; set; }
            public bool Pinned { get; set; }
            public bool Locked { get; set; }
            public bool HasAnswer { get; set; }
        }
    }
}
