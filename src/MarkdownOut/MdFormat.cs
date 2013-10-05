﻿namespace MarkdownOut {

    /// <summary>
    /// Specifies a Markdown format to apply to a line or block of text.
    /// </summary>
    public enum MdFormat {

        /// <summary>
        /// No text format.
        /// </summary>
        None,

        /// <summary>
        /// Heading 1 text format (inserts the string <c>"# "</c> in front of text).
        /// </summary>
        Heading1,

        /// <summary>
        /// Heading 2 text format (inserts the string <c>"## "</c> in front of text).
        /// </summary>
        Heading2,

        /// <summary>
        /// Heading 3 text format (inserts the string <c>"### "</c> in front of text).
        /// </summary>
        Heading3,

        /// <summary>
        /// Heading 4 text format (inserts the string <c>"#### "</c> in front of text).
        /// </summary>
        Heading4,

        /// <summary>
        /// Heading 5 text format (inserts the string <c>"##### "</c> in front of text).
        /// </summary>
        Heading5,

        /// <summary>
        /// Heading 6 text format (inserts the string <c>"###### "</c> in front of text).
        /// </summary>
        Heading6,

        /// <summary>
        /// Quote text format (inserts the string <c>"> "</c> in front of text).
        /// </summary>
        Quote,

        /// <summary>
        /// Unordered list item text format (inserts the string <c>"- "</c> in front of text).
        /// </summary>
        UnorderedListItem,

        /// <summary>
        /// Ordered list item text format (inserts the string <c>"1. "</c> in front of text).
        /// </summary>
        OrderedListItem,
    }
}