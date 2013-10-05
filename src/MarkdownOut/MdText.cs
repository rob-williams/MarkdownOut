using System;

namespace MarkdownOut {

    /// <summary>
    /// Provides static fields and methods to style and format Markdown text.
    /// </summary>
    public static class MdText {

        /// <summary>
        /// The Markdown tab string (four spaces).
        /// </summary>
        public static readonly string Tab = new string(' ', 4);

        /// <summary>
        /// The Markdown line break string (a newline followed by two spaces).
        /// </summary>
        public static readonly string LineBreak = "\r\n" + new string(' ', 2);

        /// <summary>
        /// The Markdown paragraph break string (two newlines).
        /// </summary>
        public static readonly string ParagraphBreak = "\r\n\r\n";

        /// <summary>
        /// The Markdown italic string to be wrapped around a string of text.
        /// </summary>
        public static readonly string ItalicWrap = "*";

        /// <summary>
        /// The Markdown bold string to be wrapped around a string of text.
        /// </summary>
        public static readonly string BoldWrap = "**";

        /// <summary>
        /// The Markdown code string to be wrapped around a string text.
        /// </summary>
        public static readonly string CodeWrap = "`";

        /// <summary>
        /// The Markdown strike-through string to be wrapped around a string of text.
        /// </summary>
        public static readonly string StrikeThroughWrap = "~~";

        /// <summary>
        /// The Markdown heading 1 prefix string.
        /// </summary>
        public static readonly string Heading1Prefix = "# ";

        /// <summary>
        /// The Markdown heading 2 prefix string.
        /// </summary>
        public static readonly string Heading2Prefix = "## ";

        /// <summary>
        /// The Markdown heading 3 prefix string.
        /// </summary>
        public static readonly string Heading3Prefix = "### ";

        /// <summary>
        /// The Markdown heading 4 prefix string.
        /// </summary>
        public static readonly string Heading4Prefix = "#### ";

        /// <summary>
        /// The Markdown heading 5 prefix string.
        /// </summary>
        public static readonly string Heading5Prefix = "##### ";

        /// <summary>
        /// The Markdown heading 6 prefix string.
        /// </summary>
        public static readonly string Heading6Prefix = "###### ";

        /// <summary>
        /// The Markdown quote prefix string.
        /// </summary>
        public static readonly string QuotePrefix = "> ";

        /// <summary>
        /// The Markdown unordered list item prefix string.
        /// </summary>
        public static readonly string UnorderedListItemPrefix = "- ";

        /// <summary>
        /// The default number used for ordered list items.
        /// </summary>
        public static readonly int DefaultListItemNumber = 1;

        /// <summary>
        /// The Markdown ordered list item prefix string.
        /// </summary>
        public static readonly string OrderedListItemPrefix = DefaultListItemNumber + ". ";

        /// <summary>
        /// The Markdown indent string for sublists.
        /// </summary>
        public static readonly string ListItemIndent = new string(' ', 5);

        /// <summary>
        /// Styles the provided text using the specified <see cref="MdStyle"/>.
        /// </summary>
        /// <param name="text">The text to style.</param>
        /// <param name="style">The Markdown style to apply.</param>
        /// <returns>The styled string.</returns>
        public static string Style(object text, MdStyle style) {
            string wrap;
            switch (style) {
                case MdStyle.None: wrap = String.Empty; break;
                case MdStyle.Italic: wrap = ItalicWrap; break;
                case MdStyle.Bold: wrap = BoldWrap; break;
                case MdStyle.BoldItalic: wrap = ItalicWrap + BoldWrap; break;
                case MdStyle.Code: wrap = CodeWrap; break;
                case MdStyle.StrikeThrough: wrap = StrikeThroughWrap; break;
                default: throw new ArgumentException("style");
            }
            return wrap + text + wrap;
        }

        /// <summary>
        /// Formats the provided text using the specified <see cref="MdFormat"/>. If styling is also
        /// desired, use the <see cref="StyleAndFormat"/> method or style the text first; formatting
        /// text and then styling it produces output that may not parse correctly.
        /// </summary>
        /// <param name="text">The text to format.</param>
        /// <param name="format">The Markdown format to apply.</param>
        /// <returns>The formatted string.</returns>
        public static string Format(object text, MdFormat format) {
            string prefix;
            switch (format) {
                case MdFormat.None: prefix = String.Empty; break;
                case MdFormat.Heading1: prefix = Heading1Prefix; break;
                case MdFormat.Heading2: prefix = Heading2Prefix; break;
                case MdFormat.Heading3: prefix = Heading3Prefix; break;
                case MdFormat.Heading4: prefix = Heading4Prefix; break;
                case MdFormat.Heading5: prefix = Heading5Prefix; break;
                case MdFormat.Heading6: prefix = Heading6Prefix; break;
                case MdFormat.Quote: prefix = QuotePrefix; break;
                case MdFormat.UnorderedListItem: prefix = UnorderedListItemPrefix; break;
                case MdFormat.OrderedListItem: prefix = OrderedListItemPrefix; break;
                default: throw new ArgumentException("format");
            }
            return prefix + text;
        }

        /// <summary>
        /// Styles then formats the provided text using the specified <see cref="MdStyle"/> and
        /// <see cref="MdFormat"/>.
        /// </summary>
        /// <param name="text">The text to format and style.</param>
        /// <param name="style">The Markdown style to apply.</param>
        /// <param name="format">The Markdown format to apply.</param>
        /// <returns>The formatted and styled string.</returns>
        public static string StyleAndFormat(object text, MdStyle style, MdFormat format) {
            return Format(Style(text, style), format);
        }

        /// <summary>
        /// Cleanses the provided text by replacing all tab characters with the <see cref="Tab"/>
        /// string and ensuring that all newlines are the Windows "\r\n".
        /// </summary>
        /// <param name="text">The text to cleanse.</param>
        /// <returns>
        /// The cleansed text without tab characters and only including Windows newlines.
        /// </returns>
        public static string Cleanse(string text) {
            //first, replace all tab characters with the Tab string
            text = text.Replace("\t", Tab);
            /*
             * Next, replace all Windows newlines with the Unix newline; this is done to make sure
             * the following line of code doesn't replace instances of "\r\n" with "\r\n\n". All of
             * this is done to make sure the text displays correctly on Windows machines (programs
             * such as Visual Studio do not recognize "\n" as a newline, just "\r\n").
             */
            text = text.Replace("\r\n", "\n");
            //finally, replace all Unix newlines with the Windows newline and return
            return text.Replace("\n", "\r\n");
        }
    }
}