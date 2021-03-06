using System.Collections.Generic;
using Lucene.Net.Util;
using OrchardCore.Contents.Indexing;

namespace OrchardCore.Lucene.Model
{
    public class LuceneSettings
    {
        public static readonly string[] FullTextField = new string[] { IndexingConstants.FullTextKey };

        public static string StandardAnalyzer = "standardanalyzer";

        public static LuceneVersion DefaultVersion = LuceneVersion.LUCENE_48;

        public string SearchIndex { get; set; }

        public string[] DefaultSearchFields { get; set; } = FullTextField;

        /// <summary>
        /// Gets the list of indices and their settings.
        /// </summary>
        public Dictionary<string, LuceneIndexSettings> IndexSettings { get; } = new Dictionary<string, LuceneIndexSettings>();
    }
}
