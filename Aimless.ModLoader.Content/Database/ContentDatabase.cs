﻿
using System.Collections;

namespace Aimless.ModLoader.Content.Database
{
    public class ContentDatabase<TContent> : IContentDatabase<TContent> where TContent : notnull
    {
        private readonly Dictionary<ContentKey, TContent> content = new();

        public IEnumerable<TContent> ContentValues => content.Values;
        public IEnumerable<KeyValuePair<ContentKey, TContent>> ContentEntries => content;
        public IEnumerable<ContentKey> ContentKeys => content.Keys;

        public ContentDatabase()
        {

        }
        
        public virtual bool AddContent(ContentKey key, TContent value)
        {
            return content.TryAdd(key, value);
        }

        public virtual TContent? GetContent(ContentKey key)
        {
            if (!content.TryGetValue(key, out var val))
            {
                return default;
            }
            return val;
        }
    }
}
