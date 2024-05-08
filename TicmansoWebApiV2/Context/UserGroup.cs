﻿namespace TicmansoWebApiV2.Context
{
    public class UserGroup
    {
        public string UserId { get; set; }
        public int GroupId { get; set; }

        public ApplicationUser User { get; set; }
        public Group Group { get; set; }
    }

}
