﻿using System.Linq;

namespace UpBlazor.Core.Models
{
    public class TwoUp
    {
        public TwoUp()
        {
            
        }
        public TwoUp(string userId1, string userId2)
        {
            UserId1 = userId1;
            UserId2 = userId2;
        }
        public string MartenId
        {
            get
            {
                // Ensure that there are not duplicate entries (e.g. (1,2) and (2,1))
                var userIds = new []{ UserId1, UserId2};
                return string.Join(string.Empty, userIds.OrderBy(x => x));
            }
        }

        public string UserId1 { get; set; }
        public string UserId2 { get; set; }
    }
}