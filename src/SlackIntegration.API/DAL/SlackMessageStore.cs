﻿using SlackIntegration.SlackLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SlackIntegration.DAL
{
    public class SlackMessageStore : ISlackMessageStore
    {
        public SlackDbContext DbContext { get; set; }

        public void SaveMessage(SlackMessage message)
        {
            message.TimeStamp = DateTime.Now;
            DbContext.Messages.Add(message);
            DbContext.SaveChangesAsync();
        }

        public void SaveMessage(string text, string userName = null, string channel = null)
        {
            SlackMessage message = new SlackMessage()
            {
                TimeStamp = DateTime.Now,
                Channel = channel,
                UserName = userName,
                Text = text
            };

            SaveMessage(message);
        }

        public List<SlackMessage> GetMessages()
        {
            return DbContext.Messages.ToList();
        }
    }
}